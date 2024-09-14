namespace Regon.CustomExceptions
{
    public class AppException : Exception
    {
        public AppException(string? message) : base(message)
        {
        }
    }
}
