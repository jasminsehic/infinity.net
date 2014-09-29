using System;

namespace Infinity.Models
{
    public class TeamRoomMessage
    {
        public int Id { get; internal set; }
        public string Content { get; internal set; }
        public TeamRoomMessageType MessageType { get; internal set; }
        public DateTime PostedTime { get; internal set; }
        public int PostedRoomId { get; internal set; }
        public TeamRoomAuthor PostedBy { get; internal set; }
    }
}