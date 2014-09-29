using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    public class ProjectClient
    {
        internal ProjectClient(TfsClientExecutor executor)
        {
            Executor = executor;
        }

        private TfsClientExecutor Executor { get; set; }

        public async Task<IEnumerable<Project>> GetProjects(
            ProjectState projectState = ProjectState.All,
            int count = 0,
            int skip = 0)
        {
            var request = new RestRequest("/_apis/projects");

            if (projectState != ProjectState.All)
            {
                request.AddParameter("statefilter", projectState.ToString());
            }

            if (count > 0)
            {
                request.AddParameter("top", count);
            }

            if (skip > 0)
            {
                request.AddParameter("$skip", skip);
            }

            ProjectList projects = await Executor.Execute<ProjectList>(request);
            return (projects != null) ? projects.Value : new List<Project>();
        }

        public async Task<Project> GetProject(Guid id)
        {
            Assert.NotNull(id, "id");

            var request = new RestRequest("/_apis/projects/{ProjectId}");
            request.AddUrlSegment("ProjectId", id.ToString());

            return await Executor.Execute<Project>(request);
        }

        public async Task<Project> GetProject(string name)
        {
            Assert.NotNull(name, "name");

            var request = new RestRequest("/_apis/projects/{Name}");
            request.AddUrlSegment("Name", name);

            return await Executor.Execute<Project>(request);
        }

        private class ProjectList
        {
            public int Count { get; set; }
            public List<Project> Value { get; set; }
        }
    }
}