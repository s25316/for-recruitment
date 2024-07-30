namespace SimpleApp03__System.Data.SqlClient_.Models
{
    public class Request
    {
        public required int Code { get; set; }
        public required bool ReturnInformation { get; set; }
        public string? Information { get; set; }
    }
}
