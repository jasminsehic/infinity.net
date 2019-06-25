using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to join Team Rooms and read and write messages within them.
    /// </summary>
    public class TeamRoomClient
    {
        internal TeamRoomClient(ITfsClientExecutor executor)
        {
            Executor = executor;
        }

        private ITfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Get a list of Team Rooms.
        /// </summary>
        /// <returns>The list of Team Rooms</returns>
        public async Task<IEnumerable<TeamRoom>> GetRooms()
        {
            var request = new TfsRestRequest("/_apis/chat/rooms");

            Sequence<TeamRoom> list = await Executor.Execute<Sequence<TeamRoom>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <returns>The Team Room</returns>
        public async Task<TeamRoom> GetRoom(int roomId)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}");
            request.AddUrlSegment("RoomId", roomId.ToString());

            return await Executor.Execute<TeamRoom>(request);
        }

        /// <summary>
        /// Create a new Team Room.
        /// </summary>
        /// <param name="name">The name of the Team Room to create</param>
        /// <param name="description">The description of the Team Room</param>
        /// <returns>The newly created Team Room</returns>
        public async Task<TeamRoom> CreateRoom(string name, string description)
        {
            Assert.NotNull(name, "name");
            Assert.NotNull(description, "description");

            var request = new TfsRestRequest("/_apis/chat/rooms", HttpMethod.Post);
            request.AddBody(new { name = name, description = description });

            return await Executor.Execute<TeamRoom>(request);
        }

        /// <summary>
        /// Update a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to update</param>
        /// <param name="name">The new name of the Team Room</param>
        /// <param name="description">The new description of the Team Room</param>
        /// <returns>The updated Team Room</returns>
        public async Task<TeamRoom> UpdateRoom(int roomId, string name, string description)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}", new HttpMethod("PATCH"));
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddBody(new { name = name, description = description });

            return await Executor.Execute<TeamRoom>(request);
        }

        /// <summary>
        /// Deletes a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to delete</param>
        public async Task DeleteRoom(int roomId)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}", HttpMethod.Delete);
            request.AddUrlSegment("RoomId", roomId.ToString());

            await Executor.Execute(request);
        }

        /// <summary>
        /// Write a message in a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to write to</param>
        /// <param name="content">The message to write</param>
        public async Task<TeamRoomMessage> CreateMessage(int roomId, string content)
        {
            Assert.NotNull(content, "content");

            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/messages", HttpMethod.Post);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddBody(new { content = content });
            
            return await Executor.Execute<TeamRoomMessage>(request);
        }

        /// <summary>
        /// Gets the list of messages that have been written to the Team Room.
        /// 
        /// You can filter by the PostedTime field for up to 30 days.  If there is
        /// no filter then messages from the last 24 hours will be returned.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to query messages for</param>
        /// <param name="filter">OData PostedTime filter to apply to the message list</param>
        /// <returns>The list of messages</returns>
        public async Task<IEnumerable<TeamRoomMessage>> GetMessages(int roomId, string filter = null)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/messages", HttpMethod.Get);
            request.AddUrlSegment("RoomId", roomId.ToString());

            if (filter != null)
            {
                request.AddParameter("$filter", filter);
            }

            Sequence<TeamRoomMessage> messages = await Executor.Execute<Sequence<TeamRoomMessage>>(request);
            return (messages != null) ? messages.Value : new List<TeamRoomMessage>();
        }

        /// <summary>
        /// Get the contents of a message in a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <param name="messageId">The message ID to retrieve</param>
        /// <returns>The message</returns>
        public async Task<TeamRoomMessage> GetMessage(int roomId, int messageId)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/messages/{MessageId}", HttpMethod.Get);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("MessageId", messageId.ToString());

            return await Executor.Execute<TeamRoomMessage>(request);
        }

        /// <summary>
        /// Update the content of an existing Team Room message.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <param name="messageId">The ID of the message to edit</param>
        /// <param name="content">The new content of the message</param>
        /// <returns>The updated message</returns>
        public async Task<TeamRoomMessage> UpdateMessage(int roomId, int messageId, string content)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/messages/{MessageId}", new HttpMethod("PATCH"));
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("MessageId", messageId.ToString());
            request.AddBody(new { content = content });

            return await Executor.Execute<TeamRoomMessage>(request);
        }

        /// <summary>
        /// Delete a message from a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <param name="messageId">The ID of the message to delete</param>
        public async Task DeleteMessage(int roomId, int messageId)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/messages/{MessageId}", HttpMethod.Delete);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("MessageId", messageId.ToString());
            await Executor.Execute(request);
        }

        /// <summary>
        /// Join a Team Room.  You will be listed as present in the team room until
        /// you leave.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to join</param>
        /// <param name="userId">The ID of the user to join</param>
        public async Task JoinRoom(int roomId, Guid userId)
        {
            Assert.NotNull(userId, "userId");

            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/users/{UserId}", HttpMethod.Put);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("UserId", userId.ToString());
            request.AddBody(new { userId = userId });
            await Executor.Execute(request);
        }

        /// <summary>
        /// Get the list of users in a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <returns>The list of users</returns>
        public async Task<IEnumerable<TeamRoomUserDetails>> GetUsers(int roomId)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/users");
            request.AddUrlSegment("RoomId", roomId.ToString());

            Sequence<TeamRoomUserDetails> list = await Executor.Execute<Sequence<TeamRoomUserDetails>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get the details of a user in a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <param name="userId">The ID of the user</param>
        /// <returns>The user details</returns>
        public async Task<TeamRoomUserDetails> GetUser(int roomId, Guid userId)
        {
            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/users/{UserId}");
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("UserId", userId.ToString());
            return await Executor.Execute<TeamRoomUserDetails>(request);
        }

        /// <summary>
        /// Leave a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to leave</param>
        /// <param name="userId">The ID of the user of the leaving user</param>
        public async Task LeaveRoom(int roomId, Guid userId)
        {
            Assert.NotNull(userId, "userId");

            var request = new TfsRestRequest("/_apis/chat/rooms/{RoomId}/users/{UserId}", HttpMethod.Delete);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("UserId", userId.ToString());
            await Executor.Execute(request);
        }
    }
}