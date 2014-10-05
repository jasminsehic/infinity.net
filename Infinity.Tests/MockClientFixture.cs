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
    public abstract class MockClientFixture
    {
        protected TfsClient NewMockClient(params MockRequestConfiguration[] configuration)
        {
            MockClientExecutor mockExecutor = new MockClientExecutor(configuration);
            return new TfsClient(mockExecutor);
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
    }
}