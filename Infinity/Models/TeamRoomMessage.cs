using System;

namespace Infinity.Models
{
    public enum TeamRoomMessageType
    {
        System, Normal
    }

    public class TeamRoomMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public TeamRoomMessageType MessageType { get; set; }
        public DateTime PostedTime { get; set; }
        public int PostedRoomId { get; set; }
        public Guid PostedByUserTfid { get; set; }
    }
}