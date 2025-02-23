using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace Operator_Screen_App.Connections.API
{
    public class SendLog
    {
        public static async Task<string> SendJsonPostAsync(object payload)
        {
            const string iniFilePath = ".\\Settings.ini";
            if (!File.Exists(iniFilePath))
            {
                throw new Exception("INI file not found!");
            }

            string Host = Utility.ReadIniValue(iniFilePath, "API", "Host");
            string Endpoint = Utility.ReadIniValue(iniFilePath, "API", "Endpoint");
            string Port = Utility.ReadIniValue(iniFilePath, "API", "Port");
            string Timeout = Utility.ReadIniValue(iniFilePath, "API", "Timeout");

            if (!int.TryParse(Port, out int ParsedPort))
            {
                throw new Exception("Invalid SMTP Port in INI file.");
            }
            if (!int.TryParse(Timeout, out int ParsedTimeout))
            {
                throw new Exception("Invalid SMTP Timeout in INI file");
            }

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = ParsedTimeout;
                    client.SendTimeout = ParsedTimeout;

                    using (var cts = new CancellationTokenSource(ParsedTimeout))
                    {
                        // Timeout enforced connect
                        var connectTask = client.ConnectAsync(Host, ParsedPort);
                        if (await Task.WhenAny(connectTask, Task.Delay(ParsedTimeout, cts.Token)) != connectTask)
                            throw new TimeoutException("Connection timed out.");

                        using (SslStream sslStream = new SslStream(client.GetStream(), false))
                        {
                            // Perform SSL handshake with timeout
                            var authTask = sslStream.AuthenticateAsClientAsync(Host);
                            if (await Task.WhenAny(authTask, Task.Delay(ParsedTimeout, cts.Token)) != authTask)
                                throw new TimeoutException("SSL handshake timed out.");

                            await authTask; // Ensure it completes

                            // Convert payload to JSON
                            string jsonBody = System.Text.Json.JsonSerializer.Serialize(payload);
                            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonBody);

                            // Construct HTTP POST request
                            string request = $"POST {Endpoint} HTTP/1.1\r\n" +
                                             $"Host: {Host}\r\n" +
                                             "Content-Type: application/json\r\n" +
                                             $"Content-Length: {jsonBytes.Length}\r\n" +
                                             "User-Agent: CustomClient/1.0\r\n" +
                                             "Connection: close\r\n\r\n";

                            byte[] requestBytes = Encoding.UTF8.GetBytes(request);

                            // Send headers and body
                            await sslStream.WriteAsync(requestBytes, 0, requestBytes.Length, cts.Token);
                            await sslStream.WriteAsync(jsonBytes, 0, jsonBytes.Length, cts.Token);
                            await sslStream.FlushAsync(cts.Token);

                            // Read response with timeout
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead;

                                while (true)
                                {
                                    var readTask = sslStream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                                    var completedTask = await Task.WhenAny(readTask, Task.Delay(ParsedTimeout, cts.Token));

                                    if (completedTask == readTask) // Read task completed
                                    {
                                        bytesRead = await readTask; // Get the actual bytes read
                                        if (bytesRead <= 0)
                                            break; // No more data to read

                                        memoryStream.Write(buffer, 0, bytesRead);
                                    }
                                    else
                                    {
                                        throw new TimeoutException("Reading from the server timed out.");
                                    }
                                }

                                // Convert response to string
                                string response = Encoding.UTF8.GetString(memoryStream.ToArray());

                                // Extract JSON part from response (ignoring HTTP headers)
                                int index = response.IndexOf("\r\n\r\n");
                                if (index != -1)
                                {
                                    response = response.Substring(index + 4);
                                }

                                return response;
                            }
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException("Operation timed out.");
            }
        }
    }
}
