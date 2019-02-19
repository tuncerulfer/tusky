using System;
using System.Runtime.Serialization;

namespace Tusky.Criterion
{
    public class DirectUsageException : InvalidOperationException
    {
        public DirectUsageException() : this("Not to be used directly - use inside QueryOver expression")
        {
        }

        public DirectUsageException(string message) : base(message)
        {
        }

        public DirectUsageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DirectUsageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
