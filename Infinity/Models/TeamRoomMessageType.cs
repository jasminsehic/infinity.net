namespace Infinity.Models
{
    /// <summary>
    /// The type of a message in a Team Room
    /// </summary>
    public enum TeamRoomMessageType
    {
        /// <summary>
        /// A system message, such as an indication that a
        /// user has joined or left the room.
        /// </summary>
        System,

        /// <summary>
        /// A normal message from a user to the room.
        /// </summary>
        Normal
    }
}