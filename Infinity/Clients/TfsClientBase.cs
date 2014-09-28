using System;
using System.Net;
using System.Collections.Generic;

using RestSharp;
using RestSharp.Deserializers;

using Infinity.Exceptions;
using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    public abstract class TfsClientBase
    {
        private readonly JsonDeserializer deserializer = new JsonDeserializer();

        internal TfsClientBase(TfsClientConfiguration configuration)
        {
            Assert.NotNull(configuration, "configuration");

            Configuration = configuration;
        }

        internal TfsClientConfiguration Configuration
        {
            get;
            private set;
        }

        public T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = CreateClient().Execute<T>(request);
            HandleResponse(response);
            return response.Data;
        }

        public void Execute(IRestRequest request)
        {
            IRestResponse response = CreateClient().Execute(request);
            HandleResponse(response);
        }

        private RestClient CreateClient()
        {
            RestClient client = new RestClient(Configuration.Uri);

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