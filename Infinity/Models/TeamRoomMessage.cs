using System;

namespace Infinity.Models
{
    /// <summary>
    /// A message in a Team Room.
    /// </summary>
    public class TeamRoomMessage
    {
        /// <summary>
        /// The unique ID of the message.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The type of message.
        /// </summary>
        public TeamRoomMessageType MessageType { get; set; }

        /// <summary>
        /// The time the message was posted.
        /// </summary>
        public DateTime PostedTime { get; set; }

        /// <summary>
        /// The ID of the Team Room the message was posted in.
        /// </summary>
        public int PostedRoomId { get; set; }

        /// <summary>
        /// The author of the message.
        /// </summary>
        public Identity PostedBy { get; set; }
    }
}