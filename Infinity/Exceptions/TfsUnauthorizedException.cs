using System;

using RestSharp;

namespace Infinity.Exceptions
{
    /// <summary>
    /// Exception thrown when you are not authorized to perform the requested operation.
    /// </summary>
    public class TfsUnauthorizedException : TfsRestException
    {
        internal TfsUnauthorizedException(string message, IRestResponse response)
            : base(message, response)
        {
        }
    }
}