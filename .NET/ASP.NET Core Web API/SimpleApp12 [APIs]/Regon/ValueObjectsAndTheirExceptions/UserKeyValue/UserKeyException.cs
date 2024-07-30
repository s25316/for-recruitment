using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Regon.ValueObjectsAndTheirExceptions.UserKeyValue
{
    public class UserKeyException : Exception
    {
        public UserKeyException()
        {
        }

        public UserKeyException(string? message) : base(message)
        {
        }

        public UserKeyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
