using System.Net.Http;

namespace Infinity.Exceptions
{
    /// <summary>
    /// Exception thrown when you are not authorized to perform the requested operation.
    /// </summary>
    public class TfsUnauthorizedException : TfsRestException
    {
        internal TfsUnauthorizedException(string message, HttpResponseMessage response)
            : base(message, response)
        {
        }
    }
}