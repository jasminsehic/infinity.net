using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infinity.Tests
{
    public class MockHttpMessageHandler : DelegatingHandler
    {
        private readonly List<MockHttpMessageConfiguration> configuration = new List<MockHttpMessageConfiguration>();

        public void AddConfiguration(MockHttpMessageConfiguration configuration)
        {
            this.configuration.Add(configuration);
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            foreach (MockHttpMessageConfiguration config in configuration)
            {
                if (config.Uri.Equals(request.RequestUri.PathAndQuery))
                {
                    if (config.Method != request.Method)
                    {
                        return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed)
                        {
                            RequestMessage = request
                        };
                    }

                    if (config.RequestBody != null)
                    {
                        string requestBody = request.Content != null ?
                            await request.Content.ReadAsStringAsync() :
                            "";

                        if (!config.RequestBody.Equals(requestBody))
                        {
                            return new HttpResponseMessage(HttpStatusCode.BadRequest)
                            {
                                RequestMessage = request
                            };
                        }
                    }

                    var message = new HttpResponseMessage(HttpStatusCode.OK);

                    if (config.ResponseBody != null)
                    {
                        message.Content = new StringContent(config.ResponseBody);
                    }

                    return message;
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound) {
                RequestMessage = request
            };
        }
    }
}
