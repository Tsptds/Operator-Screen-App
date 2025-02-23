using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Operator_Screen_App._ignore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Operator_Screen_App.Connections.Mail
{
    public static class Mail
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Send()
        {
            logger.Info("Attempting to send mail");

            string iniFilePath = ".\\Connections\\Mail\\Settings.ini";

            if (!File.Exists(iniFilePath))
            {
                throw new Exception("INI file not found!");
            }

            string smtpServer = ReadIniValue(iniFilePath, "SMTP", "Server");
            string smtpPort = ReadIniValue(iniFilePath, "SMTP", "Port");
            string smtpUser = ReadIniValue(iniFilePath, "SMTP", "Username");
            string smtpPass = ReadIniValue(iniFilePath, "SMTP", "Password");
            string useSSL = ReadIniValue(iniFilePath, "SMTP", "UseSSL");

            if (!int.TryParse(smtpPort, out int port))
            {
                throw new Exception("Invalid SMTP port in INI file.");
            }
#if DEBUG
            MessageBox.Show($"Port:{smtpPort}\n" +
                $"User: {smtpUser}\n" +
                $"Server: {smtpServer}");
#endif

            bool enableSSL = useSSL.ToLower() == "true";

            try
            {
                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = port,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true,
                };

                smtpClient.Send(smtpUser, ServerConfigs.emailTo, "Test Mail", "Test123");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new Exception($"Error sending email: {ex.Message}");
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
        string section, string key, string defaultValue,
        StringBuilder retVal, int size, string filePath);

        private static string ReadIniValue(string filePath, string section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", temp, 1024, filePath);
            return temp.ToString();
        }
    }
}
