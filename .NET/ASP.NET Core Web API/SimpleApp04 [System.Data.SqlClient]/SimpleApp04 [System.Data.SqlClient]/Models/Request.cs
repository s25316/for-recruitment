namespace SimpleApp04__System.Data.SqlClient_.Models
{
    public class Request <T>
    {
        public required int Code { get; set; }
        public required bool IsExistValue { get; set; }
        public T Value { get; set; } 
    }
}
