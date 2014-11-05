using System;
using System.Net;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Deserializers;
using Moq;

using Infinity;

namespace Infinity.Tests
{
    public class MockClientExecutor : ITfsClientExecutor
    {
        public MockClientExecutor(params MockRequestConfiguration[] configuration)
        {
            Configuration = configuration;
        }

        private MockRequestConfiguration[] Configuration { get; set; }

        private MockRequestConfiguration GetConfigurationForRequest(IRestRequest request)
        {
            MockRequestConfiguration config = null;

            foreach (MockRequestConfiguration c in Configuration)
            {
                string uri = request.Resource;
                string body = null;
                int getParams = 0;

                foreach (Parameter param in request.Parameters)
                {
                    if (param.Type == ParameterType.UrlSegment)
                    {
                        uri = uri.Replace(String.Format("{{{0}}}", param.Name), param.Value.ToString());
                    }
                    else if (param.Type == ParameterType.GetOrPost)
                    {
                        uri = String.Format("{0}{1}{2}={3}", uri,
                            getParams == 0 ? "?" : "&",
                            param.Name, param.Value);
                        getParams++;
                    }
                    else if (param.Type == ParameterType.RequestBody)
                    {
                        body = param.Value.ToString();
                    }
                }

                if (c.Method == request.Method &&
                    ((c.RequestBody == null && body == null) || c.RequestBody.Equals(body)) && 
                    c.Uri.Equals(uri))
                {
                    config = c;
                    break;
                }
            }

            if (config == null)
            {
                throw new Exception("Request URI not mocked");
            }

            return config;
        }

        public async Task<T> Execute<T>(IRestRequest request) where T : new()
        {
            MockRequestConfiguration configuration = GetConfigurationForRequest(request);
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();

            RestResponse<T> responseData = new RestResponse<T>
            {
                StatusCode = HttpStatusCode.OK,
                Content = configuration.ResponseBody,
            };

            responseData.Data = new JsonDeserializer().Deserialize<T>(responseData);

            restClientMock.Setup(x => x.ExecuteTaskAsync<T>(
                It.IsAny<IRestRequest>())).
                ReturnsAsync(responseData);

            IRestResponse<T> response = await restClientMock.Object.ExecuteTaskAsync<T>(request);
            return response.Data;
        }

        public async Task Execute(IRestRequest request)
        {
            MockRequestConfiguration configuration = GetConfigurationForRequest(request);
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();

            RestResponse responseData = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content = configuration.ResponseBody,
            };

            restClientMock.Setup(x => x.ExecuteTaskAsync(
                It.IsAny<IRestRequest>())).
                ReturnsAsync(responseData);

            await restClientMock.Object.ExecuteTaskAsync(request);
        }
    }
}
