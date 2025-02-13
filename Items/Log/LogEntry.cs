namespace Operator_Screen_App.Items.Log
{
    public class LogEntry
    {
        public string? logID { get; set; }
        public string? computerHash { get; set; }
        public string? ipAddress { get; set; }
        public string? userID { get; set; }
        public string? username { get; set; }
        public string? accessLocation { get; set; }
        public int accessDirection { get; set; }
        public int verifyStatusCode { get; set; }
        public string? additionalInfo { get; set; }
        public string? logTime { get; set; }
    }
}