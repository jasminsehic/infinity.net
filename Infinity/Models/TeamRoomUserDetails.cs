using System;

namespace Infinity.Models
{
    /// <summary>
    /// The information about a user in a Team Room.
    /// </summary>
    public class TeamRoomUserDetails
    {
        /// <summary>
        /// The ID of the Team Room.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// The user information for this user.
        /// </summary>
        public Identity User { get; set; }

        /// <summary>
        /// The last date the user was seen in this Team Room.
        /// </summary>
        public DateTime LastActivity { get; set; }

        /// <summary>
        /// The join date of the user.
        /// </summary>
        public DateTime JoinedDate { get; set; }

        /// <summary>
        /// Whether the user is currently online or not.
        /// </summary>
        public bool IsOnline { get; set; }
    }
}
