using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    public class GitClient : TfsClientBase
    {
        internal GitClient(TfsClientConfiguration config)
            : base(config)
        {
        }

        public async Task<IEnumerable<Repository>> GetRepositories()
        {
            RepositoryList list = await Execute<RepositoryList>(new RestRequest("/_apis/git/repositories"));
            return list.Value;
        }

        public async Task<Repository> GetRepository(Guid id)
        {
            var request = new RestRequest("/_apis/git/repositories/{RepositoryId}");
            request.AddUrlSegment("RepositoryId", id.ToString());

            return await Execute<Repository>(request);
        }

        public async Task<Repository> GetRepository(string name)
        {
            var request = new RestRequest("/_apis/git/repositories/{Name}");
            request.AddUrlSegment("Name", name);

            return await Execute<Repository>(request);
        }

        public async Task<Repository> CreateRepository(Project project, string name)
        {
            var request = new RestRequest("/_apis/git/repositories", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = name, project = new { id = project.Id } });
            return await Execute<Repository>(request);
        }

        public async Task<IEnumerable<Reference>> GetReferences(Repository repository, string filter = null)
        {
            var request = new RestRequest("/_apis/git/repositories/{RepositoryId}/refs", Method.GET);
            request.AddUrlSegment("RepositoryId", repository.Id.ToString());

            if (filter != null)
            {
                request.AddParameter("$filter", filter);
            }

            ReferenceList references = await Execute<ReferenceList>(request);
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