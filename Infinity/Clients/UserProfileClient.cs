using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    public class UserProfileClient : TfsClientBase
    {
        internal UserProfileClient(TfsClientConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<UserProfile> GetUserProfile()
        {
            UserProfileContainer container = await Execute<UserProfileContainer>(new RestRequest("/_apis/profile/profiles/me"));
            return container.Profile;
        }

        public async Task<UserProfile> GetUserProfile(Guid userId)
        {
            var request = new RestRequest("/_apis/profile/profiles/{UserId}");
            request.AddUrlSegment("UserId", userId.ToString());
            UserProfileContainer container = await Execute<UserProfileContainer>(request);
            return container.Profile;
        }

        private class UserProfileContainer
        {
            public UserProfile Profile { get; set; }
        }
    }
}