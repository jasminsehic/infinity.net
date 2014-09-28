using System;

using RestSharp;

namespace Infinity.Exceptions
{
    public class TfsRestException : Exception
    {
        internal TfsRestException(string message)
            : base(message)
        {
        }

        internal TfsRestException(string message, IRestResponse response)
            : base(message)
        {
            Response = response;
        }

        public IRestResponse Response
        {
            get;
            private set;
        }
    }
}