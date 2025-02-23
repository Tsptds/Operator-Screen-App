using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Log.Attributes;

namespace Operator_Screen_App.Connections.API
{
    internal class Post
    {
        static public string FormatDescription(LogEntry _logEntry)
        {
            // Pre-formatted text, don't add whitespaces below
            return $@"
Entry With Invalid Status Code Detected

Username:          {_logEntry.username}
User ID:           {_logEntry.userID}
Computer Hash:     {_logEntry.computerHash}
IP Address:        {_logEntry.ipAddress}
Access Location:   {_logEntry.accessLocation}
Access Direction:  {_logEntry.accessDirection} - {((AccessDirection)_logEntry.accessDirection).Format()}
Status Code:       {_logEntry.verifyStatusCode} - {((VerifyStatusCode)_logEntry.verifyStatusCode).Format()}
Additional Info:   {_logEntry.additionalInfo}
Log Time:          {_logEntry.logTime.Replace("T", " / ")}";
        }

    }
}
