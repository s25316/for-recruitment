using System.Runtime.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue
{
    public class TypJednostkiException : Exception
    {
        public TypJednostkiException()
        {
        }

        public TypJednostkiException(string? message) : base(message)
        {
        }

        public TypJednostkiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TypJednostkiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
