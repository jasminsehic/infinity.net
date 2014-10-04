using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using RestSharp;
using Xunit;
using Moq;

using Infinity;
using Infinity.Models;

namespace Infinity.Tests
{
    public abstract class ModelFixture
    {
        public delegate R ClientTask<R>(TfsClient client);

        protected R MockRequest<R>(string testName, ClientTask<Task<R>> clientTask)
        {
            Assert.NotNull(testName);

            string[] testNameComponents = testName.Split(new char[] { '.' });
            Assert.True(testNameComponents.Length > 1);

            string resourceName = String.Join("_", testNameComponents);

            byte[] resourceData = (byte[])typeof(Properties.Resources).GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            string resourceJson = System.Text.Encoding.UTF8.GetString(resourceData);

            MockTfsClientExecutor mockExecutor = new MockTfsClientExecutor(resourceJson);
            TfsClient client = new TfsClient(mockExecutor);

            R result = default(R);

            Task.Run(async () =>
            {
                result = await clientTask(client);
            }).Wait();

            return result;
        }
    }
}