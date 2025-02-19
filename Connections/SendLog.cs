using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Operator_Screen_App._ignore;

namespace Operator_Screen_App.Connections
{
    public class SendLog
    {
        private const string host = ServerConfigs.host;
        private const string Endpoint = ServerConfigs.Endpoint;
        private const int port = ServerConfigs.port;
        private const int timeoutMs = ServerConfigs.timeoutMs;
        public static async Task<string> SendJsonPostAsync(object payload)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = timeoutMs;
                    client.SendTimeout = timeoutMs;

                    using (var cts = new CancellationTokenSource(timeoutMs))
                    {
                        // Timeout enforced connect
                        var connectTask = client.ConnectAsync(host, port);
                        if (await Task.WhenAny(connectTask, Task.Delay(timeoutMs, cts.Token)) != connectTask)
                            throw new TimeoutException("Connection timed out.");

                        using (SslStream sslStream = new SslStream(client.GetStream(), false))
                        {
                            // Perform SSL handshake with timeout
                            var authTask = sslStream.AuthenticateAsClientAsync(host);
                            if (await Task.WhenAny(authTask, Task.Delay(timeoutMs, cts.Token)) != authTask)
                                throw new TimeoutException("SSL handshake timed out.");

                            await authTask; // Ensure it completes

                            // Convert payload to JSON
                            string jsonBody = System.Text.Json.JsonSerializer.Serialize(payload);
                            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonBody);

                            // Construct HTTP POST request
                            string request = $"POST {Endpoint} HTTP/1.1\r\n" +
                                             $"Host: {host}\r\n" +
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
                                    var completedTask = await Task.WhenAny(readTask, Task.Delay(timeoutMs, cts.Token));

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
