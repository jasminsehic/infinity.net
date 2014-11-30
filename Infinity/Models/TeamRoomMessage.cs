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
        public int Id { get; internal set; }

        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Content { get; internal set; }

        /// <summary>
        /// The type of message.
        /// </summary>
        public TeamRoomMessageType MessageType { get; internal set; }

        /// <summary>
        /// The time the message was posted.
        /// </summary>
        public DateTime PostedTime { get; internal set; }

        /// <summary>
        /// The ID of the Team Room the message was posted in.
        /// </summary>
        public int PostedRoomId { get; internal set; }

        /// <summary>
        /// The author of the message.
        /// </summary>
        public Identity PostedBy { get; internal set; }
    }
}