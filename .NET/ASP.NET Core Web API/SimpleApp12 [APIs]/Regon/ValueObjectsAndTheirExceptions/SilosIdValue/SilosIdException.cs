using System.Runtime.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.SilosIdValue
{
    public class SilosIdException : Exception
    {
        public SilosIdException()
        {
        }

        public SilosIdException(string? message) : base(message)
        {
        }

        public SilosIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SilosIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
