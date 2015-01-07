using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Infinity
{
    /// <summary>
    /// REST request class for TFS / Visual Studio Online
    /// </summary>
    internal class TfsRestRequest
    {
        private const string DefaultVersion = "1.0";

        private readonly Dictionary<string, object> urlSegments = new Dictionary<string, object>();
        private readonly Dictionary<string, object> parameters = new Dictionary<string, object>();
        private readonly Dictionary<string, object> headers = new Dictionary<string, object>();
        private string body;

        /// <summary>
        /// Create a REST request for a TFS server.
        /// </summary>
        /// <param name="resource">Request URI</param>
        /// <param name="method">The HTTP method</param>
        /// <param name="version">API version</param>
        internal TfsRestRequest(string resource, HttpMethod method, string version)
        {
            Resource = resource;
            Method = method;

            AddParameter("api-version", version);
        }

        /// <summary>
        /// Create a REST request for a TFS server.
        /// </summary>
        /// <param name="resource">Request URI</param>
        internal TfsRestRequest(string resource)
            : this(resource, HttpMethod.Get, DefaultVersion)
        {
        }

        /// <summary>
        /// Create a REST request for a TFS server.
        /// </summary>
        /// <param name="resource">Request URI</param>
        /// <param name="method">The HTTP method</param>
        internal TfsRestRequest(string resource, HttpMethod method)
            : this(resource, method, DefaultVersion)
        {
        }

        internal string Resource
        {
            get;
            private set;
        }

        internal HttpMethod Method
        {
            get;
            private set;
        }

        internal IDictionary<string, object> UrlSegments
        {
            get
            {
                return urlSegments;
            }
        }

        internal void AddUrlSegment(string key, object value)
        {
            urlSegments.Add(key, value);
        }

        internal IDictionary<string, object> Parameters
        {
            get
            {
                return parameters;
            }
        }

        internal void AddParameter(string key, object value)
        {
            parameters.Add(key, value);
        }

        internal void AddOptionalParameter(string key, object value)
        {
            AddOptionalParameter(key, value, () => { return value != null; });
        }

        internal void AddOptionalParameter(string key, object value, Func<bool> test)
        {
            if (test())
            {
                parameters.Add(key, value);
            }
        }

        internal IDictionary<string, object> Headers
        {
            get
            {
                return headers;
            }
        }

        internal void AddHeader(string key, object value)
        {
            headers.Add(key, value);
        }

        internal void AddBody(object body)
        {
            this.body = JsonConvert.SerializeObject(body);
        }

        internal void AddBody(string body)
        {
            this.body = body;
        }

        internal string GetBody()
        {
            return body;
        }
    }
}