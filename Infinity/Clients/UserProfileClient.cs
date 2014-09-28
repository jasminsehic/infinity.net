using System;

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

        public UserIdentity GetIdentity()
        {
            return Execute<UserIdentityContainer>(new RestRequest("/_api/_common/GetUserProfile")).Identity;
        }

        public UserIdentity GetIdentity(string tfUserId)
        {
            var request = new RestRequest("/_api/_common/GetUserProfile/{TfUserId}");
            request.AddUrlSegment("TfUserId", tfUserId);
            return Execute<UserIdentityContainer>(request).Identity;
        }

        public class UserIdentityContainer
        {
            public UserIdentity Identity { get; set; }
        }
    }
}