using System;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    public class UserProfileClient : TfsClientBase
    {
        public UserProfileClient(TfsClientConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<UserIdentity> GetIdentity()
        {
            UserIdentityContainer container = await Execute<UserIdentityContainer>(new RestRequest("/_api/_common/GetUserProfile"));
            return container.Identity;
        }

        public async Task<UserIdentity> GetIdentity(string tfUserId)
        {
            var request = new RestRequest("/_api/_common/GetUserProfile/{TfUserId}");
            request.AddUrlSegment("TfUserId", tfUserId);
            UserIdentityContainer container = await Execute<UserIdentityContainer>(request);
            return container.Identity;
        }

        public class UserIdentityContainer
        {
            public UserIdentity Identity { get; set; }
        }
    }
}