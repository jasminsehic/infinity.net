using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to access information about Team Projects inside a
    /// TFS Project Collection.
    /// </summary>
    public class ProjectClient
    {
        internal ProjectClient(ITfsClientExecutor executor)
        {
            Executor = executor;
        }

        private ITfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Get a list of all Team Projects within the current Project Collection.
        /// </summary>
        /// <param name="projectState">The state of the Team Project(s) to query</param>
        /// <param name="count">The maximum number of Team Projects to return</param>
        /// <param name="skip">The number of Team Projects to skip</param>
        /// <returns>The list of Team Projects that match the criteria</returns>
        public async Task<IEnumerable<Project>> GetProjects(
            ProjectState projectState = ProjectState.All,
            int count = 0,
            int skip = 0)
        {
            var request = new TfsRestRequest("/_apis/projects");

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

            Sequence<Project> projects = await Executor.Execute<Sequence<Project>>(request);
            return (projects != null) ? projects.Value : new List<Project>();
        }

        /// <summary>
        /// Get the Team Project by ID.
        /// 
        /// Optionally queries the "capabilities" for the team project,
        /// including source control type (TFVC or Git) and process
        /// template.
        /// </summary>
        /// <param name="id">The ID of the Team Project.</param>
        /// <param name="includeCapabilities">true to include project capabilities</param>
        /// <returns>The Team Project, or <code>null</code> if none matched</returns>
        public async Task<Project> GetProject(Guid id, bool includeCapabilities = false)
        {
            Assert.NotNull(id, "id");

            var request = new TfsRestRequest("/_apis/projects/{ProjectId}");
            request.AddUrlSegment("ProjectId", id.ToString());

            if (includeCapabilities)
            {
                request.AddParameter("includecapabilities", "true");
            }

            return await Executor.Execute<Project>(request);
        }

        /// <summary>
        /// Get the Team Project by name.
        /// 
        /// Optionally queries the "capabilities" for the team project,
        /// including source control type (TFVC or Git) and process
        /// template.
        /// </summary>
        /// <param name="name">The name of the Team Project.</param>
        /// <param name="includeCapabilities">true to include project capabilities</param>
        /// <returns>The Team Project, or <code>null</code> if none matched</returns>
        public async Task<Project> GetProject(string name, bool includeCapabilities = false)
        {
            Assert.NotNull(name, "name");

            var request = new TfsRestRequest("/_apis/projects/{Name}");
            request.AddUrlSegment("Name", name);

            if (includeCapabilities)
            {
                request.AddParameter("includecapabilities", "true");
            }

            return await Executor.Execute<Project>(request);
        }

        /// <summary>
        /// Update the project information.
        /// </summary>
        /// <param name="id">The ID of the Team Project.</param>
        /// <param name="description">The description to update in the project</param>
        /// <returns>The Team Project, after update</returns>
        public async Task<Project> UpdateProject(Guid id, string description)
        {
            Assert.NotNull(id, "id");
            Assert.NotNull(description, "description");

            var request = new TfsRestRequest("/_apis/projects/{ProjectId}", new HttpMethod("PATCH"));
            request.AddUrlSegment("ProjectId", id.ToString());
            request.AddBody(new { description = description });
            return await Executor.Execute<Project>(request);
        }

        /// <summary>
        /// Update the project information.
        /// </summary>
        /// <param name="name">The name of the project to update</param>
        /// <param name="description">The description to update in the project</param>
        /// <returns>The Team Project, after update</returns>
        public async Task<Project> UpdateProject(string name, string description)
        {
            Assert.NotNull(name, "name");
            Assert.NotNull(description, "description");

            var request = new TfsRestRequest("/_apis/projects/{Name}", new HttpMethod("PATCH"));
            request.AddUrlSegment("Name", name);
            request.AddBody(new { description = description });
            return await Executor.Execute<Project>(request);
        }
    }
}