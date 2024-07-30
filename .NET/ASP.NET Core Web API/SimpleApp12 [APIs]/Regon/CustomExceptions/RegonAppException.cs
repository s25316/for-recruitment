using System.Runtime.Serialization;

namespace Regon.CustomExceptions
{
    public class RegonAppException : Exception
    {
        public RegonAppException()
        {
        }

        public RegonAppException(string? message) : base(message)
        {
        }

        public RegonAppException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RegonAppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
