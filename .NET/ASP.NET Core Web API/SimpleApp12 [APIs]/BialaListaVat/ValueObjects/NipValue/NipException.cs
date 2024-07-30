using System.Runtime.Serialization;

namespace BialaListaVat.ValueObjects.NipValue
{
    public class NipException : Exception
    {
        public NipException()
        {
        }

        public NipException(string? message) : base(message)
        {
        }

        public NipException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
