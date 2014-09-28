using System;

using RestSharp;

namespace Infinity.Exceptions
{
    public class TfsConflictException : TfsRestException
    {
        internal TfsConflictException(string message, IRestResponse response)
            : base(message, response)
        {
        }
    }
}