using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BusinessExceptions
{
    public class InSufficientDataException : Exception
    {
        public InSufficientDataException()
        {
        }

        public InSufficientDataException(string message) : base(message)
        {
        }

        public InSufficientDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InSufficientDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
