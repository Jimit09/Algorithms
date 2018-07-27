using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BusinessExceptions
{
    public class InsufficientDataException : Exception
    {
        public InsufficientDataException()
        {
        }

        public InsufficientDataException(string message) : base(message)
        {
        }

        public InsufficientDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
