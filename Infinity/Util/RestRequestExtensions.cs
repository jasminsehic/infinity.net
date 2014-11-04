using System;

using RestSharp;

namespace Infinity.Util
{
    internal static class RestRequestExtensions
    {
        internal static void AddOptionalParameter(this IRestRequest request, string name, object value)
        {
            AddOptionalParameter(request, name, () => { return value != null; }, value);
        }

        internal static void AddOptionalParameter(this IRestRequest request, string name, Func<bool> test, object value)
        {
            if (test())
            {
                request.AddParameter(name, value);
            }
        }
    }
}