using System.Runtime.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.RegonValue
{
    public class RegonException : Exception
    {
        public RegonException()
        {
        }

        public RegonException(string? message) : base(message)
        {
        }

        public RegonException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RegonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
