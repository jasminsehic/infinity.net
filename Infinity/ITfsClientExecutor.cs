using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using RestSharp;

[assembly: InternalsVisibleTo("Infinity.Tests")]
namespace Infinity
{
    internal interface ITfsClientExecutor
    {
        Task<T> Execute<T>(TfsRestRequest request) where T : new();
        Task Execute(TfsRestRequest request);
    }
}
