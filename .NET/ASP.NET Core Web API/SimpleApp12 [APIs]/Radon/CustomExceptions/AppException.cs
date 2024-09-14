namespace Radon.CustomExceptions
{
    /// <summary>
    /// Exception for Admin/Proggramer
    /// </summary>
    public class AppException : Exception
    {
        public AppException(string? message) : base(message)
        {
        }
    }
}
