namespace SimpleApp01__System.Data.SqlClient_.Models
{
    public class Request <T>
    {
        public int Code { get; set; }
        public bool HasValue { get; set; }
        public T? Value { get; set; }
    }
}
