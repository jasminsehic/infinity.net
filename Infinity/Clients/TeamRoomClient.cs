using System;
using System.Collections.Generic;

using RestSharp;

using Infinity.Models;

namespace Infinity.Clients
{
    public class TeamRoomClient : TfsClientBase
    {
        public TeamRoomClient(TfsClientConfiguration configuration)
            : base(configuration)
        {
        }

        public IEnumerable<TeamRoom> Rooms()
        {
            return Execute<TeamRoomList>(new RestRequest("/_apis/chat/rooms")).Value;
        }

        public void Join(TeamRoom room)
        {
            var userProfileClient = new UserProfileClient(Configuration);
            var identity = userProfileClient.GetIdentity();

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{Identity}", Method.PUT);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.AddUrlSegment("Identity", identity.TeamFoundationId);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { userId = identity.TeamFoundationId });
            Execute(request);
        }

        public void Write(TeamRoom room, string message)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.POST);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { content = message });
            Execute(request);
        }

        public IEnumerable<TeamRoomMessage> Messages(TeamRoom room, string filter = null)
        {
            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/messages", Method.GET);
            request.AddUrlSegment("RoomId", room.Id.ToString());

            if (filter != null)
            {
                request.AddParameter("$filter", filter);
            }

            TeamMessageList messages = Execute<TeamMessageList>(request);
            return (messages != null) ? messages.Value : null;
        }

        public void Leave(TeamRoom room)
        {
            var userProfileClient = new UserProfileClient(Configuration);
            var identity = userProfileClient.GetIdentity();

            var request = new RestRequest("/_apis/chat/rooms/{RoomId}/users/{Identity}", Method.DELETE);
            request.AddUrlSegment("RoomId", room.Id.ToString());
            request.AddUrlSegment("Identity", identity.TeamFoundationId);
            request.RequestFormat = DataFormat.Json;
            Execute(request);
        }

        private class TeamRoomList
        {
            public int Count { get; set; }
            public List<TeamRoom> Value { get; set; }
        }

        private class TeamMessageList
        {
            public int Count { get; set; }
            public List<TeamRoomMessage> Value { get; set; }
        }
    }
}