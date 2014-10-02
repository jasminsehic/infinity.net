using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to access information about Git repositories managed in a
    /// TFS Project Collection.
    /// </summary>
    public class GitClient
    {
        internal GitClient(ITfsClientExecutor executor)
        {
            Executor = executor;
        }

        private ITfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Get a list of all Git repositories managed in a TFS Project Collection.
        /// </summary>
        /// <returns>A list of repositories in the Project Collection</returns>
        public async Task<IEnumerable<Repository>> GetRepositories()
        {
            RepositoryList list = await Executor.Execute<RepositoryList>(new RestRequest("/_apis/git/repositories"));
            return list.Value;
        }

        /// <summary>
        /// Get the information about a Git repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the Git repository</param>
        /// <returns>The Git repository</returns>
        public async Task<Repository> GetRepository(Guid id)
        {
            Assert.NotNull(id, "id");

            var request = new RestRequest("/_apis/git/repositories/{RepositoryId}");
            request.AddUrlSegment("RepositoryId", id.ToString());

            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Get the information about a Git repository by its name.
        /// </summary>
        /// <param name="name">The name of the Git repository</param>
        /// <returns>The Git repository</returns>
        public async Task<Repository> GetRepository(string name)
        {
            Assert.NotNull(name, "name");

            var request = new RestRequest("/_apis/git/repositories/{Name}");
            request.AddUrlSegment("Name", name);

            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Create a new Git repository inside a Team Project.
        /// </summary>
        /// <param name="project">The Team Project that will contain this repository</param>
        /// <param name="name">The name of the repository to create</param>
        /// <returns>The Git repository created</returns>
        /// <exception cref="Infinity.Exceptions.TfsConflictException">If a repository by the same name already exists</exception>
        public async Task<Repository> CreateRepository(Project project, string name)
        {
            Assert.NotNull(project, "project");
            Assert.NotNull(name, "name");

            var request = new RestRequest("/_apis/git/repositories", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = name, project = new { id = project.Id } });
            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Get the references (branches, tags, notes) in the given repository.
        /// </summary>
        /// <param name="repository">The Git repository</param>
        /// <param name="filter">The string prefix to match, excepting the <code>refs/</code> prefix.  For example, <code>heads/</code> will return branches.</param>
        /// <returns>The list of references.</returns>
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