using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Screen_App.Connections
{
    public class RequestLog
    {
        private const string host = "interview.ones.com.tr";
        private const string Endpoint = "/API/AccessLog"; 
        private const int port = 443;

        public static string FetchJson()
        {
            try
            {
                using (TcpClient client = new TcpClient(host, port))
                using (SslStream sslStream = new SslStream(client.GetStream(), false))
                {
                    // Perform the SSL handshake
                    sslStream.AuthenticateAsClient(host);

                    // Send HTTP GET request with JSON response format
                    string request = $"GET {Endpoint} HTTP/1.1\r\n" +
                                 $"Host: {host}\r\n" +
                                 "Accept: application/json\r\n" + // Request JSON format
                                 "User-Agent: CustomClient/1.0\r\n" + // Some servers require User-Agent
                                 "Connection: close\r\n\r\n";

                    byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                    sslStream.Write(requestBytes, 0, requestBytes.Length);
                    sslStream.Flush();

                    // Read response
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = sslStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesRead);
                        }

                        // Convert response to string
                        string response = Encoding.ASCII.GetString(memoryStream.ToArray());
                        Console.WriteLine(response);

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
