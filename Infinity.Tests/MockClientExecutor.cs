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

                foreach (Parameter param in request.Parameters)
                {
                    if (param.Type == ParameterType.UrlSegment)
                    {
                        uri = uri.Replace(String.Format("{{{0}}}", param.Name), param.Value.ToString());
                    }
                }

                if (c.Method == request.Method && c.Uri.Equals(uri))
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
                Content = configuration.Response,
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
                Content = configuration.Response,
            };

            restClientMock.Setup(x => x.ExecuteTaskAsync(
                It.IsAny<IRestRequest>())).
                ReturnsAsync(responseData);

            IRestResponse response = await restClientMock.Object.ExecuteTaskAsync(request);
        }
    }
}