using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

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
            TeamRoomList list = await Executor.Execute<TeamRoomList>(new RestRequest("/_apis/chat/rooms"));
            return list.Value;
        }

        /// <summary>
        /// Get a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room</param>
        /// <returns>The Team Room</returns>
        public async Task<TeamRoom> GetRoom(int roomId)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}");
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

            var request = new RestRequest("/_apis/chat/rooms", Method.POST);
            request.RequestFormat = DataFormat.Json;
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
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}", Method.PATCH);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = name, description = description });
            return await Executor.Execute<TeamRoom>(request);
        }

        /// <summary>
        /// Deletes a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to delete</param>
        public async Task DeleteRoom(int roomId)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}", Method.DELETE);
            request.AddUrlSegment("RoomId", roomId.ToString());
            await Executor.Execute(request);
        }

        /// <summary>
        /// Join a Team Room.  You will be listed as present in the team room until
        /// you leave.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to join</param>
        /// <param name="userId">The ID of the user to join</param>
        public async Task Join(int roomId, Guid userId)
        {
            Assert.NotNull(userId, "userId");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{UserId}", Method.PUT);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("UserId", userId.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { userId = userId });
            await Executor.Execute(request);
        }

        /// <summary>
        /// Write a message in a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to write to</param>
        /// <param name="message">The message to write</param>
        public async Task Write(Guid roomId, string message)
        {
            Assert.NotNull(roomId, "roomId");
            Assert.NotNull(message, "message");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.POST);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { content = message });
            await Executor.Execute(request);
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
        public async Task<IEnumerable<TeamRoomMessage>> GetMessages(Guid roomId, string filter = null)
        {
            Assert.NotNull(roomId, "roomId");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.GET);
            request.AddUrlSegment("RoomId", roomId.ToString());

            if (filter != null)
            {
                request.AddParameter("$filter", filter);
            }

            TeamRoomMessageList messages = await Executor.Execute<TeamRoomMessageList>(request);
            return (messages != null) ? messages.Value : new List<TeamRoomMessage>();
        }

        /// <summary>
        /// Leave a Team Room.
        /// </summary>
        /// <param name="roomId">The ID of the Team Room to leave</param>
        /// <param name="userId">The ID of the user of the leaving user</param>
        public async Task Leave(Guid roomId, Guid userId)
        {
            Assert.NotNull(roomId, "roomId");
            Assert.NotNull(userId, "userId");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{UserId}", Method.DELETE);
            request.AddUrlSegment("RoomId", roomId.ToString());
            request.AddUrlSegment("UserId", userId.ToString());
            request.RequestFormat = DataFormat.Json;
            await Executor.Execute(request);
        }

        private class TeamRoomList
        {
            public int Count { get; set; }
            public List<TeamRoom> Value { get; set; }
        }

        private class TeamRoomMessageList
        {
            public int Count { get; set; }
            public List<TeamRoomMessage> Value { get; set; }
        }
    }
}