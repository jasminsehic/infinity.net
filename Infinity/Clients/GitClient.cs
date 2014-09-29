using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    public class GitClient
    {
        internal GitClient(TfsClientExecutor restClient)
        {
            Executor = restClient;
        }

        private TfsClientExecutor Executor { get; set; }

        public async Task<IEnumerable<Repository>> GetRepositories()
        {
            RepositoryList list = await Executor.Execute<RepositoryList>(new RestRequest("/_apis/git/repositories"));
            return list.Value;
        }

        public async Task<Repository> GetRepository(Guid id)
        {
            Assert.NotNull(id, "id");

            var request = new RestRequest("/_apis/git/repositories/{RepositoryId}");
            request.AddUrlSegment("RepositoryId", id.ToString());

            return await Executor.Execute<Repository>(request);
        }

        public async Task<Repository> GetRepository(string name)
        {
            Assert.NotNull(name, "name");

            var request = new RestRequest("/_apis/git/repositories/{Name}");
            request.AddUrlSegment("Name", name);

            return await Executor.Execute<Repository>(request);
        }

        public async Task<Repository> CreateRepository(Project project, string name)
        {
            Assert.NotNull(project, "project");
            Assert.NotNull(name, "name");

            var request = new RestRequest("/_apis/git/repositories", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = name, project = new { id = project.Id } });
            return await Executor.Execute<Repository>(request);
        }

        public async Task<IEnumerable<Reference>> GetReferences(Repository repository, string filter = null)
        {
            Assert.NotNull(repository, "repository");

            var request = new RestRequest("/_apis/git/repositories/{RepositoryId}/refs", Method.GET);
            request.AddUrlSegment("RepositoryId", repository.Id.ToString());

            if (filter != null)
            {
                request.AddParameter("$filter", filter);
            }

            ReferenceList references = await Executor.Execute<ReferenceList>(request);
            return (references != null) ? references.Value : new List<Reference>();
        }

        private class RepositoryList
        {
            public int Count { get; set; }
            public List<Repository> Value { get; set; }
        }

        private class ReferenceList
        {
            public int Count { get; set; }
            public List<Reference> Value { get; set; }
        }
    }
}