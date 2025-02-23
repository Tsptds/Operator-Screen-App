using System.Net.Mail;
using System.Net;
using Operator_Screen_App.Items.Node;
using Operator_Screen_App.Items.Log.Attributes;

namespace Operator_Screen_App.Connections.Mail
{
    public static class Mail
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Send(Node _logEntry)
        {
            logger.Info("Attempting to send mail");

            string iniFilePath = ".\\Settings.ini";

            if (!File.Exists(iniFilePath))
            {
                logger.Error("INI file not found");
                throw new Exception("INI file not found!");
            }

            string smtpServer = Utility.ReadIniValue(iniFilePath, "SMTP", "Server");
            string smtpPort = Utility.ReadIniValue(iniFilePath, "SMTP", "Port");
            string smtpUser = Utility.ReadIniValue(iniFilePath, "SMTP", "Username");
            string smtpPass = Utility.ReadIniValue(iniFilePath, "SMTP", "Password");
            string useSSL = Utility.ReadIniValue(iniFilePath, "SMTP", "UseSSL");

            string mailReceiver = Utility.ReadIniValue(iniFilePath, "MAIL", "MailTarget");
            string mailHeader = "Operator Screen App: Unconfirmed Invalid Entry Detected";

            if (!int.TryParse(smtpPort, out int port))
            {
                logger.Error("Invalid SMTP Port in INI file");
                throw new Exception("Invalid SMTP Port in INI file");
            }
#if DEBUG
            MessageBox.Show($"Port:{smtpPort}\n" +
                $"Server: {smtpServer}");
#endif

            bool enableSSL = useSSL.ToLower() == "true";
            logger.Info("Constructing Mail");
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUser),
                    Subject = mailHeader,
                    Body = FormatMailHTML(_logEntry), // This should return an HTML string
                    IsBodyHtml = true // Ensure Mail renders it as HTML
                };

                mailMessage.To.Add(mailReceiver);

                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = port,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true
                };

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new Exception($"Error sending email: {ex.Message}");
            }
        }

        private static string FormatMailHTML(Node _logEntry)
        {
            try
            {
                var data = _logEntry.Data;
                return @"
<html>
<body>
    <p><strong>Entry With Invalid Status Code Detected</strong></p>
    <table border='1' cellpadding='5' cellspacing='0' style='border-collapse: collapse;'>
        <tr><td><strong>LogID</strong></td><td>" + data.logID + @"</td></tr>
        <tr><td><strong>Username</strong></td><td>" + data.username + @"</td></tr>
        <tr><td><strong>User ID</strong></td><td>" + data.userID + @"</td></tr>
        <tr><td><strong>Computer Hash</strong></td><td>" + data.computerHash + @"</td></tr>
        <tr><td><strong>IP Address</strong></td><td>" + data.ipAddress + @"</td></tr>
        <tr><td><strong>Access Location</strong></td><td>" + data.accessLocation + @"</td></tr>
        <tr><td><strong>Access Direction</strong></td><td>" + data.accessDirection + " - " + ((AccessDirection)data.accessDirection).Format() + @"</td></tr>
        <tr><td><strong>Status Code</strong></td><td>" + data.verifyStatusCode + " - " + ((VerifyStatusCode)data.verifyStatusCode).Format() + @"</td></tr>
        <tr><td><strong>Additional Info</strong></td><td>" + data.additionalInfo + @"</td></tr>
        <tr><td><strong>Log Time</strong></td><td>" + data.logTime.Replace("T", " / ") + @"</td></tr>
    </table>
</body>
</html>";
            }
            catch (Exception ex)
            {
                throw new Exception($"Mailing Failed: {ex.Message}");
            }
        }
    }
}
