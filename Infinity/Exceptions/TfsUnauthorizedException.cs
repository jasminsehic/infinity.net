using System;

using RestSharp;

namespace Infinity.Exceptions
{
    public class TfsUnauthorizedException : TfsRestException
    {
        internal TfsUnauthorizedException(string message, IRestResponse response)
            : base(message, response)
        {
        }
    }
}