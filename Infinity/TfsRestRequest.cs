using System;

using RestSharp;

namespace Infinity
{
    /// <summary>
    /// REST request class for TFS / Visual Studio Online
    /// </summary>
    public class TfsRestRequest : RestRequest
    {
        private const string DefaultVersion = "1.0";

        /// <summary>
        /// Create a REST request for a TFS server.
        /// </summary>
        /// <param name="resource">Request URI</param>
        /// <param name="method">The HTTP method</param>
        /// <param name="version">API version</param>
        public TfsRestRequest(string resource, Method method, string version)
            : base(resource, method)
        {
            AddParameter("api-version", version, ParameterType.QueryString);
        }

        /// <summary>
        /// Create a REST request for a TFS server.
        /// </summary>
        /// <param name="resource">Request URI</param>
        public TfsRestRequest(string resource)
            : this(resource, Method.GET, DefaultVersion)
        {
        }

        /// <summary>
        /// Create a REST request for a TFS server.
        /// </summary>
        /// <param name="resource">Request URI</param>
        /// <param name="method">The HTTP method</param>
        public TfsRestRequest(string resource, Method method)
            : this(resource, method, DefaultVersion)
        {
        }
    }
}
