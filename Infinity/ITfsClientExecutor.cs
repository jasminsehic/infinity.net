using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Infinity.Tests")]
namespace Infinity
{
    internal interface ITfsClientExecutor
    {
        Task<T> Execute<T>(TfsRestRequest request) where T : new();
        Task Execute(TfsRestRequest request);
        Task Execute(TfsRestRequest request, Stream outputStream);
    }
}
