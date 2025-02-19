using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Operator_Screen_App._ignore;

namespace Operator_Screen_App.Connections
{
    public class RequestLog
    {
        private const string host = ServerConfigs.host;
        private const string Endpoint = ServerConfigs.Endpoint;
        private const int port = ServerConfigs.port;
        private const int timeoutMs = ServerConfigs.timeoutMs;

        public static async Task<string> FetchJsonGetAsync()
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = timeoutMs;
                    client.SendTimeout = timeoutMs;

                    await client.ConnectAsync(host, port);

                    using (SslStream sslStream = new SslStream(client.GetStream(), false))
                    {
                        // Perform SSL handshake
                        await sslStream.AuthenticateAsClientAsync(host);

                        // Send HTTP GET request with JSON response format
                        string request = $"GET {Endpoint} HTTP/1.1\r\n" +
                                 $"Host: {host}\r\n" +
                                 "Accept: application/json\r\n" + // Request JSON format
                                 "User-Agent: CustomClient/1.0\r\n" + // Some servers require User-Agent
                                 "Connection: close\r\n\r\n";

                        byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                        await sslStream.WriteAsync(requestBytes, 0, requestBytes.Length);
                        await sslStream.FlushAsync();

                        // Read response
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            CancellationTokenSource cts = new CancellationTokenSource(timeoutMs);
                            byte[] buffer = new byte[4096];
                            int bytesRead;

                            while ((bytesRead = await sslStream.ReadAsync(buffer, 0, buffer.Length, cts.Token)) > 0)
                            {
                                memoryStream.Write(buffer, 0, bytesRead);
                            }

                            // Convert response to string
                            string response = Encoding.UTF8.GetString(memoryStream.ToArray());

#if DEBUG
                            MessageBox.Show(response, "Unhandled Response");
#endif
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
            catch (OperationCanceledException)
            {
                throw new TimeoutException("Operation timed out.");
            }
        }
    }
}
