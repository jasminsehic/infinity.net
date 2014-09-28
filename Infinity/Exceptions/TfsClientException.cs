using System;

namespace Infinity.Exceptions
{
    public class TfsClientException : Exception
    {
        protected TfsClientException(string message)
            : base(message)
        {
        }

        protected TfsClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}