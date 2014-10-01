using System;

using RestSharp;

namespace Infinity.Exceptions
{
    /// <summary>
    /// Exception thrown when you attempt to perform an action that
    /// would conflict with the existing state of the server.
    /// </summary>
    public class TfsConflictException : TfsRestException
    {
        internal TfsConflictException(string message, IRestResponse response)
            : base(message, response)
        {
        }
    }
}