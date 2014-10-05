using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;
using Xunit;

using Infinity;
using Infinity.Models;

namespace Infinity.Tests.Models
{
    public class TeamRoomFixture : MockClientFixture
    {
        [Fact]
        public void CanGetRooms()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/chat/rooms",
                    ResponseResource = "TeamRoom.GetRooms",
                });

            IList<TeamRoom> rooms = base.ExecuteSync<IEnumerable<TeamRoom>>(
                () => { return client.TeamRoom.GetRooms(); }).ToList();

            Assert.Equal(5, rooms.Count);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[0].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[0].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[0].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[0].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 01, 24, 19, 19, 00, 210, DateTimeKind.Utc).ToLocalTime(), rooms[0].CreatedDate);
            Assert.Equal("", rooms[0].Description);
            Assert.Equal(true, rooms[0].HasAdminPermissions);
            Assert.Equal(true, rooms[0].HasReadWritePermissions);
            Assert.Equal(305, rooms[0].Id);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 38, 543, DateTimeKind.Utc).ToLocalTime(), rooms[0].LastActivity);
            Assert.Equal("Fabrikam-Fiber-Git Team Room", rooms[0].Name);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[1].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[1].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[1].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[1].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 01, 24, 19, 20, 37, 410, DateTimeKind.Utc).ToLocalTime(), rooms[1].CreatedDate);
            Assert.Equal("", rooms[1].Description);
            Assert.Equal(true, rooms[1].HasAdminPermissions);
            Assert.Equal(true, rooms[1].HasReadWritePermissions);
            Assert.Equal(306, rooms[1].Id);
            Assert.Equal(new DateTime(2014, 01, 24, 19, 20, 37, 410, DateTimeKind.Utc).ToLocalTime(), rooms[1].LastActivity);
            Assert.Equal("Fabrikam-Fiber-TFVC Team Room", rooms[1].Name);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[2].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[2].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[2].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[2].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 01, 27, 23, 03, 55, 663, DateTimeKind.Utc).ToLocalTime(), rooms[2].CreatedDate);
            Assert.Equal("", rooms[2].Description);
            Assert.Equal(true, rooms[2].HasAdminPermissions);
            Assert.Equal(true, rooms[2].HasReadWritePermissions);
            Assert.Equal(307, rooms[2].Id);
            Assert.Equal(new DateTime(2014, 01, 27, 23, 03, 55, 663, DateTimeKind.Utc).ToLocalTime(), rooms[2].LastActivity);
            Assert.Equal("Quality assurance Room", rooms[2].Name);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[3].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[3].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[3].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[3].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 15, 14, 00, 36, 443, DateTimeKind.Utc).ToLocalTime(), rooms[3].CreatedDate);
            Assert.Equal("", rooms[3].Description);
            Assert.Equal(true, rooms[3].HasAdminPermissions);
            Assert.Equal(false, rooms[3].HasReadWritePermissions);
            Assert.Equal(2686, rooms[3].Id);
            Assert.Equal(new DateTime(2014, 05, 15, 14, 00, 36, 443, DateTimeKind.Utc).ToLocalTime(), rooms[3].LastActivity);
            Assert.Equal("TestGit Team Room", rooms[3].Name);

            Assert.Equal("Chuck Reinhart", rooms[4].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), rooms[4].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), rooms[4].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), rooms[4].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 27, 20, 28, 11, 493, DateTimeKind.Utc).ToLocalTime(), rooms[4].CreatedDate);
            Assert.Equal("updated room description", rooms[4].Description);
            Assert.Equal(true, rooms[4].HasAdminPermissions);
            Assert.Equal(true, rooms[4].HasReadWritePermissions);
            Assert.Equal(4158, rooms[4].Id);
            Assert.Equal(new DateTime(2014, 05, 27, 20, 28, 11, 493, DateTimeKind.Utc).ToLocalTime(), rooms[4].LastActivity);
            Assert.Equal("renamedRoom", rooms[4].Name);
        }

        [Fact]
        public void CanGetRoom()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/chat/rooms/4207",
                    ResponseResource = "TeamRoom.GetRoom",
                });

            TeamRoom room = base.ExecuteSync<TeamRoom>(
                () => { return client.TeamRoom.GetRoom(4207); });

            Assert.Equal("Chuck Reinhart", room.CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc).ToLocalTime(), room.CreatedDate);
            Assert.Equal("used for API doc generation", room.Description);
            Assert.Equal(true, room.HasAdminPermissions);
            Assert.Equal(true, room.HasReadWritePermissions);
            Assert.Equal(4207, room.Id);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc).ToLocalTime(), room.LastActivity);
            Assert.Equal("newCreatedRoom", room.Name);
        }

        [Fact]
        public void CanCreateRoom()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/chat/rooms",
                    Method = RestSharp.Method.POST,
                    RequestObject = new {
                        name = "newCreatedRoom",
                        description = "used for API doc generation"
                    },
                    ResponseResource = "TeamRoom.CreateRoom",
                });

            TeamRoom room = base.ExecuteSync<TeamRoom>(
                () => { return client.TeamRoom.CreateRoom("newCreatedRoom", "used for API doc generation"); });

            Assert.Equal("Chuck Reinhart", room.CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc).ToLocalTime(), room.CreatedDate);
            Assert.Equal("used for API doc generation", room.Description);
            Assert.Equal(true, room.HasAdminPermissions);
            Assert.Equal(true, room.HasReadWritePermissions);
            Assert.Equal(4207, room.Id);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc).ToLocalTime(), room.LastActivity);
            Assert.Equal("newCreatedRoom", room.Name);
        }

        [Fact]
        public void CanUpdateRoom()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/chat/rooms/431",
                    Method = RestSharp.Method.PATCH,
                    RequestObject = new
                    {
                        name = "renamedRoom",
                        description = "updated room description"
                    },
                    ResponseResource = "TeamRoom.UpdateRoom",
                });

            TeamRoom room = base.ExecuteSync<TeamRoom>(
                () => { return client.TeamRoom.UpdateRoom(431, "renamedRoom", "updated room description"); });

            Assert.Equal("Jamal Hartnett", room.CreatedBy.DisplayName);
            Assert.Equal(new Guid("d291b0c4-a05c-4ea6-8df1-4b41d5f39eff"), room.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d291b0c4-a05c-4ea6-8df1-4b41d5f39eff"), room.CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d291b0c4-a05c-4ea6-8df1-4b41d5f39eff"), room.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 04, 29, 18, 45, 10, 590, DateTimeKind.Utc).ToLocalTime(), room.CreatedDate);
            Assert.Equal("updated room description", room.Description);
            Assert.Equal(true, room.HasAdminPermissions);
            Assert.Equal(true, room.HasReadWritePermissions);
            Assert.Equal(431, room.Id);
            Assert.Equal(new DateTime(2014, 04, 29, 18, 45, 10, 590, DateTimeKind.Utc).ToLocalTime(), room.LastActivity);
            Assert.Equal("renamedRoom", room.Name);
        }

        [Fact]
        public void CanDeleteRoom()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/chat/rooms/431",
                    Method = RestSharp.Method.DELETE
                });

            base.ExecuteSync(
                () => { return client.TeamRoom.DeleteRoom(431); });
        }
    }
}