using System;
using System.Net.Http;
using Xunit;

namespace Infinity.Tests
{
    public class ClientExecutorFixture
    {
        [Theory]
        [InlineData("test/1.2.3")]
        [InlineData("test/1.2.3 foo/0.1.1 bar/4.2.2")]
        public void ClientExecutor_CanSetUserAgent(string given)
        {
            TfsClientExecutor executor = new TfsClientExecutor(new TfsClientConfiguration()
            {
                Url = new Uri("http://dummy.contoso.com/"),
                UserAgent = given,
            });

            HttpRequestMessage requestMessage = executor.CreateRequestMessage(new TfsRestRequest("/dummy"));
            Assert.Equal(given, requestMessage.Headers.UserAgent.ToString());
        }

        [Fact]
        public void ClientExecutor_SetsDefaultUserAgent()
        {
            TfsClientExecutor executor = new TfsClientExecutor(new TfsClientConfiguration()
            {
                Url = new Uri("http://dummy.contoso.com/")
            });

            HttpRequestMessage requestMessage = executor.CreateRequestMessage(new TfsRestRequest("/dummy"));

            string[] components = requestMessage.Headers.UserAgent.ToString().Split(new char[] { '/' }, 2);
            string[] version = components[1].Split(new char[] { '.' });

            Assert.Equal("Infinity.Net", components[0]);
            Assert.Equal(3, version.Length);

            int.Parse(version[0]);
            int.Parse(version[1]);
            int.Parse(version[2]);
        }

        [Fact]
        public void ClientExecutor_CanCreateRelativePathAndQuery()
        {
            TfsClientExecutor executor = new TfsClientExecutor(new TfsClientConfiguration()
            {
                Url = new Uri("http://dummy.contoso.com/DefaultCollection"),
            });

            HttpRequestMessage requestMessage = executor.CreateRequestMessage(new TfsRestRequest("/relative/to/root"));
            Assert.Equal("/DefaultCollection/relative/to/root", requestMessage.RequestUri.AbsolutePath);
        }
    }
}
