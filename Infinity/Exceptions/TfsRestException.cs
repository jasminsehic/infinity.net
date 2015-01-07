using System;
using System.Net.Http;

namespace Infinity.Exceptions
{
    /// <summary>
    /// Exception thrown when a REST call failed.
    /// </summary>
    public class TfsRestException : Exception
    {
        internal TfsRestException(string message)
            : base(message)
        {
        }

        internal TfsRestException(string message, HttpResponseMessage response)
            : base(message)
        {
            Response = response;
        }

        /// <summary>
        /// The REST response that led to the failure.
        /// </summary>
        public HttpResponseMessage Response
        {
            get;
            private set;
        }
    }
}