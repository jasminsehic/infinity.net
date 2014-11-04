using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to query information about a project's teams.
    /// </summary>
    public class TeamClient
    {
        internal TeamClient(ITfsClientExecutor executor)
        {
            Executor = executor;
        }

        /// <summary>
        /// The REST API version of this client
        /// </summary>
        public string Version
        {
            get
            {
                return "1.0";
            }
        }

        private ITfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Get a list of teams for a project.
        /// </summary>
        /// <param name="projectId">The project ID to query teams for</param>
        /// <returns>The list of teams</returns>
        public async Task<IEnumerable<Team>> GetTeams(Guid projectId)
        {
            Assert.NotNull(projectId, "projectId");

            var request = new RestRequest("/_apis/projects/{ProjectId}/teams");
            request.AddUrlSegment("ProjectId", projectId.ToString());
            request.AddParameter("api-version", Version);

            TeamList list = await Executor.Execute<TeamList>(request);
            return list.Value;
        }

        /// <summary>
        /// Get a project's team.
        /// </summary>
        /// <param name="projectId">The project ID that contains the team</param>
        /// <param name="teamId">The team ID to query</param>
        /// <returns>The team</returns>
        public async Task<Team> GetTeam(Guid projectId, Guid teamId)
        {
            Assert.NotNull(projectId, "projectId");
            Assert.NotNull(teamId, "teamId");

            var request = new RestRequest("/_apis/projects/{ProjectId}/teams/{TeamId}");
            request.AddUrlSegment("ProjectId", projectId.ToString());
            request.AddUrlSegment("TeamId", teamId.ToString());
            request.AddParameter("api-version", Version);

            return await Executor.Execute<Team>(request);
        }

        /// <summary>
        /// Get the team members for a team.
        /// </summary>
        /// <param name="projectId">The ID of the project that contains the team</param>
        /// <param name="teamId">The ID of the team</param>
        /// <returns>A list of team members</returns>
        public async Task<IEnumerable<TeamMember>> GetTeamMembers(Guid projectId, Guid teamId)
        {
            Assert.NotNull(projectId, "projectId");
            Assert.NotNull(teamId, "teamId");

            var request = new RestRequest("/_apis/projects/{ProjectId}/teams/{TeamId}/members");
            request.AddUrlSegment("ProjectId", projectId.ToString());
            request.AddUrlSegment("TeamId", teamId.ToString());
            request.AddParameter("api-version", Version);

            TeamMemberList list = await Executor.Execute<TeamMemberList>(request);
            return list.Value;
        }

        private class TeamList
        {
            public int Count { get; set; }
            public List<Team> Value { get; set; }
        }

        private class TeamMemberList
        {
            public int Count { get; set; }
            public List<TeamMember> Value { get; set; }
        }
    }
}