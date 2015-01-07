using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

using Infinity;
using Infinity.Models;

namespace Infinity.Tests
{
    public abstract class MockClientFixture : IDisposable
    {
        private MockHttpMessageHandler messageHandler = new MockHttpMessageHandler();

        protected MockHttpMessageHandler MessageHandler
        {
            get
            {
                return messageHandler;
            }
        }

        protected TfsClient NewMockClient()
        {
            TfsClientExecutor tfsExecutor = new TfsClientExecutor(new TfsClientConfiguration
            {
                Url = new Uri("https://mock.contoso.com/"),
            });
            tfsExecutor.MessageHandler = messageHandler;
            return new TfsClient(tfsExecutor);
        }

        public delegate T SyncTask<T>();

        protected R ExecuteSync<R>(SyncTask<Task<R>> task)
        {
            R result = default(R);

            Task.Run(async () =>
            {
                result = await task();
            }).Wait();

            return result;
        }

        protected void ExecuteSync(SyncTask<Task> task)
        {
            Task.Run(async () =>
            {
                await task();
            }).Wait();
        }

        public void Dispose()
        {
            messageHandler.Dispose();
        }
    }
}