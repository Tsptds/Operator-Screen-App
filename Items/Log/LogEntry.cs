namespace Operator_Screen_App.Items.Log
{
    public class LogEntry
    {
        public string? LogID { get; set; }
        public string? ComputerHash { get; set; }
        public string? IPAddress { get; set; }
        public string? UserID { get; set; }
        public string? Username { get; set; }
        public string? AccessLocation { get; set; }
        public int AccessDirection { get; set; }
        public int VerifyStatusCode { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? LogTime { get; set; }
    }
}