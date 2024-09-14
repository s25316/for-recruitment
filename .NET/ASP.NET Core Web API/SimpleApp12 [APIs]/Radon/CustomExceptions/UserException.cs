namespace Radon.CustomExceptions
{
    /// <summary>
    /// Exceptions for User/Client
    /// </summary>
    public class UserException : Exception
    {
        public UserException(string? message) : base(message)
        {
        }
    }
}
