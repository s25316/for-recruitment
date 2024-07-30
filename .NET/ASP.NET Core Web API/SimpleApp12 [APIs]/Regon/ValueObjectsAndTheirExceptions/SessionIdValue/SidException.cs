using System.Runtime.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.SessionIdValue
{
    public class SidException : Exception
    {
        public SidException()
        {
        }

        public SidException(string? message) : base(message)
        {
        }

        public SidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
