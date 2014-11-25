using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Exceptions;
using Infinity.Models;
using Infinity.Util;

namespace Infinity
{
    internal class TfsClientExecutor : ITfsClientExecutor
    {
        private readonly JsonDeserializer deserializer = new JsonDeserializer();

        internal TfsClientExecutor(TfsClientConfiguration configuration)
        {
            Assert.NotNull(configuration, "configuration");
            Assert.NotNull(configuration.Url, "configuration.Url");

            Configuration = configuration;
        }

        internal TfsClientConfiguration Configuration
        {
            get;
            private set;
        }

        public async Task<T> Execute<T>(TfsRestRequest request) where T : new()
        {
            IRestResponse<T> response = await CreateClient().ExecuteTaskAsync<T>(request);
            HandleResponse(response);
            return response.Data;
        }

        public async Task Execute(TfsRestRequest request)
        {
            IRestResponse response = await CreateClient().ExecuteTaskAsync(request);
            HandleResponse(response);
        }

        private IRestClient CreateClient()
        {
            RestClient client = new RestClient(Configuration.Url.ToString());
            client.AddHandler("application/json", deserializer);

            if (Configuration.UserAgent != null)
            {
                client.UserAgent = Configuration.UserAgent;
            }

            if (Configuration.Username != null)
            {
                client.Authenticator = new HttpBasicAuthenticator(Configuration.Username, Configuration.Password);
            }

            return client;
        }

        private bool HasHeader(IRestResponse response, string headerName)
        {
            foreach (Parameter header in response.Headers)
            {
                if (header.Name.Equals(headerName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void HandleMovedStatus(IRestResponse response)
        {
            if (HasHeader(response, "WWW-Authenticate"))
            {
                throw new TfsUnauthorizedException("Unauthorized", response);
            }
        }

        private void HandleConflictStatus(IRestResponse response)
        {
            Dictionary<string, string> failure = deserializer.Deserialize<Dictionary<string, string>>(response);

            if (failure.ContainsKey("message"))
            {
                throw new TfsConflictException(failure["message"], response);
            }
        }

        private void HandleResponse(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.Unauthorized:
                    throw new TfsUnauthorizedException("Unauthorized", response);
                case HttpStatusCode.Moved:
                    HandleMovedStatus(response);
                    goto default;
                case HttpStatusCode.Conflict:
                    HandleConflictStatus(response);
                    goto default;
                default:
                    throw new TfsRestException(
                        String.Format("Unexpected HTTP response {0}", response.StatusCode.ToString()), response);
            }
        }
    }
}