using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;
using Infinity.Models;

namespace Infinity.Tests.Models
{
    public class TeamRoomFixture : MockClientFixture
    {
        [Fact]
        public void TeamRoom_GetRooms()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms?api-version=1.0",
                    ResponseResource = "TeamRoom.GetRooms",
                });

            IList<TeamRoom> rooms = base.ExecuteSync<IEnumerable<TeamRoom>>(
                () => { return NewMockClient().TeamRoom.GetRooms(); }).ToList();

            Assert.Equal(5, rooms.Count);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[0].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[0].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[0].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[0].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 01, 24, 19, 19, 00, 210, DateTimeKind.Utc), rooms[0].CreatedDate);
            Assert.Equal("", rooms[0].Description);
            Assert.True(rooms[0].HasAdminPermissions);
            Assert.True(rooms[0].HasReadWritePermissions);
            Assert.Equal(305, rooms[0].Id);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 38, 543, DateTimeKind.Utc), rooms[0].LastActivity);
            Assert.Equal("Fabrikam-Fiber-Git Team Room", rooms[0].Name);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[1].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[1].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[1].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[1].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 01, 24, 19, 20, 37, 410, DateTimeKind.Utc), rooms[1].CreatedDate);
            Assert.Equal("", rooms[1].Description);
            Assert.True(rooms[1].HasAdminPermissions);
            Assert.True(rooms[1].HasReadWritePermissions);
            Assert.Equal(306, rooms[1].Id);
            Assert.Equal(new DateTime(2014, 01, 24, 19, 20, 37, 410, DateTimeKind.Utc), rooms[1].LastActivity);
            Assert.Equal("Fabrikam-Fiber-TFVC Team Room", rooms[1].Name);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[2].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[2].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[2].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[2].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 01, 27, 23, 03, 55, 663, DateTimeKind.Utc), rooms[2].CreatedDate);
            Assert.Equal("", rooms[2].Description);
            Assert.True(rooms[2].HasAdminPermissions);
            Assert.True(rooms[2].HasReadWritePermissions);
            Assert.Equal(307, rooms[2].Id);
            Assert.Equal(new DateTime(2014, 01, 27, 23, 03, 55, 663, DateTimeKind.Utc), rooms[2].LastActivity);
            Assert.Equal("Quality assurance Room", rooms[2].Name);

            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", rooms[3].CreatedBy.DisplayName);
            Assert.Equal(new Guid("47d25e84-de54-49ce-8f3d-351c77422775"), rooms[3].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=47d25e84-de54-49ce-8f3d-351c77422775"), rooms[3].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/47d25e84-de54-49ce-8f3d-351c77422775"), rooms[3].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 15, 14, 00, 36, 443, DateTimeKind.Utc), rooms[3].CreatedDate);
            Assert.Equal("", rooms[3].Description);
            Assert.True(rooms[3].HasAdminPermissions);
            Assert.False(rooms[3].HasReadWritePermissions);
            Assert.Equal(2686, rooms[3].Id);
            Assert.Equal(new DateTime(2014, 05, 15, 14, 00, 36, 443, DateTimeKind.Utc), rooms[3].LastActivity);
            Assert.Equal("TestGit Team Room", rooms[3].Name);

            Assert.Equal("Chuck Reinhart", rooms[4].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), rooms[4].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), rooms[4].CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), rooms[4].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 27, 20, 28, 11, 493, DateTimeKind.Utc), rooms[4].CreatedDate);
            Assert.Equal("updated room description", rooms[4].Description);
            Assert.True(rooms[4].HasAdminPermissions);
            Assert.True(rooms[4].HasReadWritePermissions);
            Assert.Equal(4158, rooms[4].Id);
            Assert.Equal(new DateTime(2014, 05, 27, 20, 28, 11, 493, DateTimeKind.Utc), rooms[4].LastActivity);
            Assert.Equal("renamedRoom", rooms[4].Name);
        }

        [Fact]
        public void TeamRoom_GetRoom()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/4207?api-version=1.0",
                    ResponseResource = "TeamRoom.GetRoom",
                });

            TeamRoom room = base.ExecuteSync<TeamRoom>(
                () => { return NewMockClient().TeamRoom.GetRoom(4207); });

            Assert.Equal("Chuck Reinhart", room.CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc), room.CreatedDate);
            Assert.Equal("used for API doc generation", room.Description);
            Assert.True(room.HasAdminPermissions);
            Assert.True(room.HasReadWritePermissions);
            Assert.Equal(4207, room.Id);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc), room.LastActivity);
            Assert.Equal("newCreatedRoom", room.Name);
        }

        [Fact]
        public void TeamRoom_CreateRoom()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms?api-version=1.0",
                    Method = HttpMethod.Post,
                    RequestObject = new {
                        name = "newCreatedRoom",
                        description = "used for API doc generation"
                    },
                    ResponseResource = "TeamRoom.CreateRoom",
                });

            TeamRoom room = base.ExecuteSync<TeamRoom>(
                () => { return NewMockClient().TeamRoom.CreateRoom("newCreatedRoom", "used for API doc generation"); });

            Assert.Equal("Chuck Reinhart", room.CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), room.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc), room.CreatedDate);
            Assert.Equal("used for API doc generation", room.Description);
            Assert.True(room.HasAdminPermissions);
            Assert.True(room.HasReadWritePermissions);
            Assert.Equal(4207, room.Id);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 40, 987, DateTimeKind.Utc), room.LastActivity);
            Assert.Equal("newCreatedRoom", room.Name);
        }

        [Fact]
        public void TeamRoom_UpdateRoom()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/431?api-version=1.0",
                    Method = new HttpMethod("PATCH"),
                    RequestObject = new
                    {
                        name = "renamedRoom",
                        description = "updated room description"
                    },
                    ResponseResource = "TeamRoom.UpdateRoom",
                });

            TeamRoom room = base.ExecuteSync<TeamRoom>(
                () => { return NewMockClient().TeamRoom.UpdateRoom(431, "renamedRoom", "updated room description"); });

            Assert.Equal("Jamal Hartnett", room.CreatedBy.DisplayName);
            Assert.Equal(new Guid("d291b0c4-a05c-4ea6-8df1-4b41d5f39eff"), room.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d291b0c4-a05c-4ea6-8df1-4b41d5f39eff"), room.CreatedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d291b0c4-a05c-4ea6-8df1-4b41d5f39eff"), room.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 04, 29, 18, 45, 10, 590, DateTimeKind.Utc), room.CreatedDate);
            Assert.Equal("updated room description", room.Description);
            Assert.True(room.HasAdminPermissions);
            Assert.True(room.HasReadWritePermissions);
            Assert.Equal(431, room.Id);
            Assert.Equal(new DateTime(2014, 04, 29, 18, 45, 10, 590, DateTimeKind.Utc), room.LastActivity);
            Assert.Equal("renamedRoom", room.Name);
        }

        [Fact]
        public void TeamRoom_DeleteRoom()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/431?api-version=1.0",
                    Method = HttpMethod.Delete
                });

            base.ExecuteSync(
                () => { return NewMockClient().TeamRoom.DeleteRoom(431); });
        }

        [Fact]
        public void TeamRoom_CreateMessage()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/305/messages?api-version=1.0",
                    Method = HttpMethod.Post,
                    RequestObject = new
                    {
                        content = "Here's a new message"
                    },
                    ResponseResource = "TeamRoom.CreateMessage",
                });

            TeamRoomMessage message = base.ExecuteSync<TeamRoomMessage>(
                () => { return NewMockClient().TeamRoom.CreateMessage(305, "Here's a new message"); });

            Assert.Equal("Here's a new message", message.Content);
            Assert.Equal(83626, message.Id);
            Assert.Equal(TeamRoomMessageType.Normal, message.MessageType);
            Assert.Equal("Chuck Reinhart", message.PostedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), message.PostedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), message.PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), message.PostedBy.Url);
            Assert.Equal(305, message.PostedRoomId);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 38, 543, DateTimeKind.Utc), message.PostedTime);
        }

        [Fact]
        public void TeamRoom_GetMessages()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/305/messages?api-version=1.0",
                    ResponseBody = "{ \"count\": 0, \"value\": [] }",
                });

            IList<TeamRoomMessage> rooms = base.ExecuteSync<IEnumerable<TeamRoomMessage>>(
                () => { return NewMockClient().TeamRoom.GetMessages(305); }).ToList();

            Assert.Equal(0, rooms.Count);
        }

        [Fact]
        public void TeamRoom_GetMessagesWithDateRange()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/2/messages?api-version=1.0&$filter=postedtime%20ge%2010/06/2014",
                    ResponseResource = "TeamRoom.GetMessages"
                });

            IList<TeamRoomMessage> messages = base.ExecuteSync<IEnumerable<TeamRoomMessage>>(
                () => { return NewMockClient().TeamRoom.GetMessages(2, "postedtime ge 10/06/2014"); }).ToList();

            Assert.Equal(4, messages.Count);

            Assert.Equal("Edward Thomson entered the room", messages[0].Content);
            Assert.Equal(74012, messages[0].Id);
            Assert.Equal(TeamRoomMessageType.System, messages[0].MessageType);
            Assert.Equal("[DefaultCollection]\\Project Collection Service Accounts", messages[0].PostedBy.DisplayName);
            Assert.Equal(new Guid("48b1ff63-9db1-4704-ae7a-43950011e061"), messages[0].PostedBy.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=48b1ff63-9db1-4704-ae7a-43950011e061"), messages[0].PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/48b1ff63-9db1-4704-ae7a-43950011e061"), messages[0].PostedBy.Url);
            Assert.Equal(6522, messages[0].PostedRoomId);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 05, 727, DateTimeKind.Utc), messages[0].PostedTime);

            Assert.Equal("This is a test message.", messages[1].Content);
            Assert.Equal(74014, messages[1].Id);
            Assert.Equal(TeamRoomMessageType.Normal, messages[1].MessageType);
            Assert.Equal("Edward Thomson", messages[1].PostedBy.DisplayName);
            Assert.Equal(new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[1].PostedBy.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[1].PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[1].PostedBy.Url);
            Assert.Equal(6522, messages[1].PostedRoomId);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 30, 510, DateTimeKind.Utc), messages[1].PostedTime);

            Assert.Equal("This is\nanother\ntest.", messages[2].Content);
            Assert.Equal(74015, messages[2].Id);
            Assert.Equal(TeamRoomMessageType.Normal, messages[2].MessageType);
            Assert.Equal("Edward Thomson", messages[2].PostedBy.DisplayName);
            Assert.Equal(new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[2].PostedBy.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[2].PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[2].PostedBy.Url);
            Assert.Equal(6522, messages[2].PostedRoomId);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 34, 417, DateTimeKind.Utc), messages[2].PostedTime);

            Assert.Equal("This is a test with an emoticon.  (d)", messages[3].Content);
            Assert.Equal(74017, messages[3].Id);
            Assert.Equal(TeamRoomMessageType.Normal, messages[3].MessageType);
            Assert.Equal("Edward Thomson", messages[3].PostedBy.DisplayName);
            Assert.Equal(new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[3].PostedBy.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[3].PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/fd19aec1-3119-4671-80d7-5dcc4943211d"), messages[3].PostedBy.Url);
            Assert.Equal(6522, messages[3].PostedRoomId);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 55, 107, DateTimeKind.Utc), messages[3].PostedTime);
        }

        [Fact]
        public void TeamRoom_GetMessage()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/2/messages/305?api-version=1.0",
                    ResponseResource = "TeamRoom.GetMessage"
                });

            TeamRoomMessage message = base.ExecuteSync<TeamRoomMessage>(
                () => { return NewMockClient().TeamRoom.GetMessage(2, 305); });

            Assert.Equal("This is a test with an emoticon.  (d)", message.Content);
            Assert.Equal(74017, message.Id);
            Assert.Equal(TeamRoomMessageType.Normal, message.MessageType);
            Assert.Equal("Edward Thomson", message.PostedBy.DisplayName);
            Assert.Equal(new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d"), message.PostedBy.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=fd19aec1-3119-4671-80d7-5dcc4943211d"), message.PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/fd19aec1-3119-4671-80d7-5dcc4943211d"), message.PostedBy.Url);
            Assert.Equal(6522, message.PostedRoomId);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 55, 107, DateTimeKind.Utc), message.PostedTime);
        }

        [Fact]
        public void TeamRoom_UpdateMessage()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/305/messages/83626?api-version=1.0",
                    Method = new HttpMethod("PATCH"),
                    RequestObject = new { content = "Updated message" },
                    ResponseResource = "TeamRoom.UpdateMessage",
                });

            TeamRoomMessage message = base.ExecuteSync<TeamRoomMessage>(
                () => { return NewMockClient().TeamRoom.UpdateMessage(305, 83626, "Updated message"); });

            Assert.Equal("Updated message", message.Content);
            Assert.Equal(83626, message.Id);
            Assert.Equal(TeamRoomMessageType.Normal, message.MessageType);
            Assert.Equal("Chuck Reinhart", message.PostedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), message.PostedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), message.PostedBy.ImageUrl);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), message.PostedBy.Url);
            Assert.Equal(305, message.PostedRoomId);
            Assert.Equal(new DateTime(2014, 05, 28, 16, 37, 38, 543, DateTimeKind.Utc), message.PostedTime);
        }

        [Fact]
        public void TeamRoom_DeleteMessage()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/305/messages/83626?api-version=1.0",
                    Method = HttpMethod.Delete,
                });

            base.ExecuteSync(
                () => { return NewMockClient().TeamRoom.DeleteMessage(305, 83626); });
        }

        [Fact]
        public void TeamRoom_JoinRoom()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/2/users/6db828be-599b-4214-a11d-93067d90744d?api-version=1.0",
                    Method = HttpMethod.Put,
                    RequestObject = new { userId = "6db828be-599b-4214-a11d-93067d90744d" },
                });

            base.ExecuteSync(
                () => { return NewMockClient().TeamRoom.JoinRoom(2, new Guid("6db828be-599b-4214-a11d-93067d90744d")); });
        }

        [Fact]
        public void TeamRoom_LeaveRoom()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/2/users/6db828be-599b-4214-a11d-93067d90744d?api-version=1.0",
                    Method = HttpMethod.Delete,
                });

            base.ExecuteSync(
                () => { return NewMockClient().TeamRoom.LeaveRoom(2, new Guid("6db828be-599b-4214-a11d-93067d90744d")); });
        }

        [Fact]
        public void TeamRoom_GetUsers()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/6522/users?api-version=1.0",
                    ResponseResource = "TeamRoom.GetUsers"
                });

            IList<TeamRoomUserDetails> users = base.ExecuteSync<IEnumerable<TeamRoomUserDetails>>(
                () => { return NewMockClient().TeamRoom.GetUsers(6522); }).ToList();

            Assert.Equal(1, users.Count);

            Assert.True(users[0].IsOnline);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 26, 167, DateTimeKind.Utc), users[0].JoinedDate);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 55, 107, DateTimeKind.Utc), users[0].LastActivity);
            Assert.Equal(6522, users[0].RoomId);
            Assert.Equal("Edward Thomson", users[0].User.DisplayName);
            Assert.Equal(new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d"), users[0].User.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=fd19aec1-3119-4671-80d7-5dcc4943211d"), users[0].User.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/fd19aec1-3119-4671-80d7-5dcc4943211d"), users[0].User.Url);
        }

        [Fact]
        public void TeamRoom_GetUser()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/chat/rooms/6522/users/fd19aec1-3119-4671-80d7-5dcc4943211d?api-version=1.0",
                    ResponseResource = "TeamRoom.GetUser"
                });

            TeamRoomUserDetails user = base.ExecuteSync<TeamRoomUserDetails>(
                () => { return NewMockClient().TeamRoom.GetUser(6522, new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d")); });

            Assert.True(user.IsOnline);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 26, 167, DateTimeKind.Utc), user.JoinedDate);
            Assert.Equal(new DateTime(2014, 10, 07, 21, 12, 55, 107, DateTimeKind.Utc), user.LastActivity);
            Assert.Equal(6522, user.RoomId);
            Assert.Equal("Edward Thomson", user.User.DisplayName);
            Assert.Equal(new Guid("fd19aec1-3119-4671-80d7-5dcc4943211d"), user.User.Id);
            Assert.Equal(new Uri("https://ethomson.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=fd19aec1-3119-4671-80d7-5dcc4943211d"), user.User.ImageUrl);
            Assert.Equal(new Uri("https://ethomson.vssps.visualstudio.com/_apis/Identities/fd19aec1-3119-4671-80d7-5dcc4943211d"), user.User.Url);
        }
    }
}