using System;
using System.Collections.Generic;
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
        protected T MockRequest<T>(string testName, params string[] args)
        {
            Assert.NotNull(testName);

            string[] testNameComponents = testName.Split(new char[] { '.' });
            Assert.True(testNameComponents.Length > 1);

            string resourceName = String.Join("_", testNameComponents);

            byte[] resourceData = (byte[])typeof(Properties.Resources).GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            string resourceJson = System.Text.Encoding.UTF8.GetString(resourceData);

            MockTfsClientExecutor mockExecutor = new MockTfsClientExecutor(resourceJson);
            TfsClient client = new TfsClient(mockExecutor);

            object model = client;

            for (int i = 0; i < testNameComponents.Length - 1; i++)
            {
                model = model.GetType().GetProperty(testNameComponents[i]).GetValue(model);
            }

            MethodInfo testMethodInfo = model.GetType().GetMethod(testNameComponents[testNameComponents.Length - 1]);

            T result = default(T);

            Task.Run(async () =>
            {
                result = await (Task<T>)testMethodInfo.Invoke(model, args);
            }).Wait();

            return result;
        }
    }
}