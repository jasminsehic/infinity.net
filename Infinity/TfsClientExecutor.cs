using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Infinity.Exceptions;
using Infinity.Util;

namespace Infinity
{
    internal class TfsClientExecutor : ITfsClientExecutor
    {
        private static readonly string DefaultUserAgent;

        static TfsClientExecutor()
        {
            Assembly assembly = typeof(TfsClientExecutor).GetTypeInfo().Assembly;
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);

            DefaultUserAgent = String.Format("Infinity.Net/{0}.{1}.{2}",
                assemblyName.Version.Major, assemblyName.Version.Minor, assemblyName.Version.Revision);
        }

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

        public HttpMessageHandler MessageHandler
        {
            get;
            set;
        }

        private async Task<HttpResponseMessage> SendRequest(TfsRestRequest request)
        {
            HttpRequestMessage requestMessage = CreateRequestMessage(request);

            using (HttpClient client = CreateClient())
            {
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
                await HandleResponse(responseMessage);
                return responseMessage;
            }
        }

        public async Task<T> Execute<T>(TfsRestRequest request) where T : new()
        {
            HttpResponseMessage responseMessage = await SendRequest(request);

            string responseContent = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task Execute(TfsRestRequest request)
        {
            await SendRequest(request);
        }

        public async Task Execute(TfsRestRequest request, Stream output)
        {
            HttpResponseMessage responseMessage = await SendRequest(request);
            await responseMessage.Content.CopyToAsync(output);
        }

        private bool IsAzureDevOps()
        {
            return Configuration.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) &&
                (Configuration.Url.Host.EndsWith(".visualstudio.com", StringComparison.OrdinalIgnoreCase) ||
                Configuration.Url.Host.EndsWith(".azure.com", StringComparison.OrdinalIgnoreCase) ||
                Configuration.Url.Host.EndsWith(".tfspreview.com", StringComparison.OrdinalIgnoreCase));
        }

        private HttpClientHandler CreateClientHandler()
        {
            HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false };

            if (Configuration.Credentials != null && !IsAzureDevOps())
            {
                handler.PreAuthenticate = true;
                handler.Credentials = Configuration.Credentials;
            }

            return handler;
        }

        private HttpClient CreateClient()
        {
            HttpClient client;
            HttpMessageHandler messageHandler = MessageHandler ?? CreateClientHandler();
            bool disposeHandler = MessageHandler != null ? false : true;

            client = new HttpClient(messageHandler, disposeHandler);

            /* Hack: VSO doesn't give 401s proper, it redirects you to a
             * signin page.  Front-load basic credentials if they were
             * provided.
             */
            if (IsAzureDevOps())
            {
                if (Configuration.OAuthToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.OAuthToken);
                }
                else if (Configuration.Credentials != null)
                {
                    string concat = String.Format("{0}:{1}", Configuration.Credentials.UserName, Configuration.Credentials.Password);
                    string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(concat));

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", base64);
                }
            }

            client.BaseAddress = Configuration.Url;

            return client;
        }

        internal HttpRequestMessage CreateRequestMessage(TfsRestRequest request)
        {
            UriBuilder url = new UriBuilder(Configuration.Url);
            url.Path = UrlHelpers.JoinPath(Configuration.Url.AbsolutePath, GetRequestPath(request));
            url.Query = GetRequestQuery(request);

            HttpRequestMessage message = new HttpRequestMessage(request.Method, url.Uri);

            message.Headers.UserAgent.ParseAdd(
                Configuration.UserAgent ?? DefaultUserAgent);

            foreach (KeyValuePair<string, object> header in request.Headers)
            {
                message.Headers.Add(header.Key, header.Value.ToString());
            }

            string body = request.GetBody();

            if (body != null)
            {
                message.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            return message;
        }

        private string FormatValue(object value)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            else
            {
                return value.ToString();
            }
        }

        private string GetRequestPath(TfsRestRequest request)
        {
            string path = request.Resource;

            foreach (KeyValuePair<string, object> urlSegment in request.UrlSegments)
            {
                path = path.Replace(String.Format("{{{0}}}", urlSegment.Key), FormatValue(urlSegment.Value));
            }

            return path;
        }

        private string GetRequestQuery(TfsRestRequest request)
        {
            StringBuilder requestPath = new StringBuilder();
            int parameterCount = 0;

            foreach (KeyValuePair<string, object> parameter in request.Parameters)
            {
                if (parameterCount++ > 0)
                {
                    requestPath.Append('&');
                }

                requestPath.Append(Uri.EscapeUriString(parameter.Key));
                requestPath.Append('=');
                requestPath.Append(Uri.EscapeUriString(FormatValue(parameter.Value)));
            }

            return requestPath.ToString();
        }

        private bool HasHeader(HttpResponseMessage response, string headerName)
        {
            foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
            {
                if (header.Key.Equals(headerName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void HandleMovedStatus(HttpResponseMessage response)
        {
            if (HasHeader(response, "WWW-Authenticate"))
            {
                throw new TfsUnauthorizedException("Unauthorized", response);
            }
        }

        private async Task HandleConflictStatus(HttpResponseMessage response)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            Dictionary<string, string> failure = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

            if (failure.ContainsKey("message"))
            {
                throw new TfsConflictException(failure["message"], response);
            }
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.Unauthorized:
                    throw new TfsUnauthorizedException("Unauthorized", response);
                case HttpStatusCode.Redirect:
                    HandleMovedStatus(response);
                    goto default;
                case HttpStatusCode.Conflict:
                    await HandleConflictStatus(response);
                    goto default;
                default:
                    throw new TfsRestException(
                        String.Format("Unexpected HTTP response {0}", response.StatusCode.ToString()), response);
            }
        }
    }
}
