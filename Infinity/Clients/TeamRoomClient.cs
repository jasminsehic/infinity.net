using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    public class TeamRoomClient : TfsClientBase
    {
        internal TeamRoomClient(TfsClientConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<IEnumerable<TeamRoom>> GetRooms()
        {
            TeamRoomList list = await Execute<TeamRoomList>(new RestRequest("/_apis/chat/rooms"));
            return list.Value;
        }

        public async Task Join(TeamRoom room, UserProfile profile)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{Identity}", Method.PUT);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.AddUrlSegment("Identity", profile.Id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { userId = profile.Id });
            await Execute(request);
        }

        public async Task Write(TeamRoom room, string message)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.POST);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { content = message });
            await Execute(request);
        }

        public async Task<IEnumerable<TeamRoomMessage>> GetMessages(TeamRoom room, string filter = null)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.GET);
            request.AddUrlSegment("RoomId", room.Id.ToString());

            if (filter != null)
            {
                request.AddParameter("$filter", filter);
            }

            TeamRoomMessageList messages = await Execute<TeamRoomMessageList>(request);
            return (messages != null) ? messages.Value : new List<TeamRoomMessage>();
        }

        public async Task Leave(TeamRoom room, UserProfile profile)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{Identity}", Method.DELETE);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.AddUrlSegment("Identity", profile.Id.ToString());
            request.RequestFormat = DataFormat.Json;
            await Execute(request);
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