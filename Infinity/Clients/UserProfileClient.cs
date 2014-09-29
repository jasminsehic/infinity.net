using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    public class UserProfileClient
    {
        internal UserProfileClient(TfsClientExecutor executor)
        {
            Executor = executor;
        }

        private TfsClientExecutor Executor { get; set; }

        public async Task<UserProfile> GetUserProfile()
        {
            UserProfileContainer container = await Executor.Execute<UserProfileContainer>(new RestRequest("/_apis/profile/profiles/me"));
            return container.Profile;
        }

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