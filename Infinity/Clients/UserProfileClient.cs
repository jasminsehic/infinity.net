using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to query user profile information.
    /// </summary>
    public class UserProfileClient
    {
        internal UserProfileClient(ITfsClientExecutor executor)
        {
            Executor = executor;
        }

        private ITfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Get the user profile of the currently authenticated user.
        /// </summary>
        /// <returns>The user profile of the current user</returns>
        public async Task<UserProfile> GetUserProfile()
        {
            UserProfileContainer container = await Executor.Execute<UserProfileContainer>(new RestRequest("/_apis/profile/profiles/me"));
            return container.Profile;
        }

        /// <summary>
        /// Get the user profile of the given user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to query</param>
        /// <returns>The user profile of the given user</returns>
        public async Task<UserProfile> GetUserProfile(Guid userId)
        {
            var request = new RestRequest("/_apis/profile/profiles/{UserId}");
            request.AddUrlSegment("UserId", userId.ToString());
            UserProfileContainer container = await Executor.Execute<UserProfileContainer>(request);
            return container.Profile;
        }

        private class UserProfileContainer
        {
            public UserProfile Profile { get; set; }
        }
    }
}