using System;
using System.Net;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Deserializers;
using Moq;

using Infinity;

namespace Infinity.Tests
{
    public class MockTfsClientExecutor : ITfsClientExecutor
    {
        public MockTfsClientExecutor(string responseContent)
        {
            ResponseContent = responseContent;
        }

        private string ResponseContent { get; set; }

        public async Task<T> Execute<T>(IRestRequest request) where T : new()
        {
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();

            RestResponse<T> responseData = new RestResponse<T>
            {
                StatusCode = HttpStatusCode.OK,
                Content = ResponseContent,
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
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();

            RestResponse responseData = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content = ResponseContent,
            };

            restClientMock.Setup(x => x.ExecuteTaskAsync(
                It.IsAny<IRestRequest>())).
                ReturnsAsync(responseData);

            IRestResponse response = await restClientMock.Object.ExecuteTaskAsync(request);
        }
    }
}