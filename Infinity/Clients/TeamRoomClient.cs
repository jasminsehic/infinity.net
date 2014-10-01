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
        internal TeamRoomClient(TfsClientExecutor executor)
        {
            Executor = executor;
        }

        private TfsClientExecutor Executor { get; set; }

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
        /// Join a Team Room.  You will be listed as present in the team room until
        /// you leave.
        /// </summary>
        /// <param name="room">The Team Room to join</param>
        /// <param name="profile">The profile of the joining user</param>
        public async Task Join(TeamRoom room, UserProfile profile)
        {
            Assert.NotNull(room, "room");
            Assert.NotNull(profile, "profile");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{Identity}", Method.PUT);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.AddUrlSegment("Identity", profile.Id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { userId = profile.Id });
            await Executor.Execute(request);
        }

        /// <summary>
        /// Write a message in a Team Room.
        /// </summary>
        /// <param name="room">The Team Room to write to</param>
        /// <param name="message">The message to write</param>
        public async Task Write(TeamRoom room, string message)
        {
            Assert.NotNull(room, "room");
            Assert.NotNull(message, "message");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.POST);
            request.AddUrlSegment("RoomId", room.Id.ToString());
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
        /// <param name="room">Team Room to query messages for</param>
        /// <param name="filter">OData PostedTime filter to apply to the message list</param>
        /// <returns>The list of messages</returns>
        public async Task<IEnumerable<TeamRoomMessage>> GetMessages(TeamRoom room, string filter = null)
        {
            Assert.NotNull(room, "room");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.GET);
            request.AddUrlSegment("RoomId", room.Id.ToString());

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
        /// <param name="room">The Team Room to leave</param>
        /// <param name="profile">The profile of the leaving user</param>
        public async Task Leave(TeamRoom room, UserProfile profile)
        {
            Assert.NotNull(room, "room");
            Assert.NotNull(profile, "profile");

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{Identity}", Method.DELETE);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.AddUrlSegment("Identity", profile.Id.ToString());
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