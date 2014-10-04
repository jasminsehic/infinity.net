using System;

namespace Infinity.Models
{
    /// <summary>
    /// The identity of a member of a team.
    /// </summary>
    public class TeamMember
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The display name of the user.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// The unique (to a collection) name for the user.
        /// </summary>
        public string UniqueName { get; private set; }

        /// <summary>
        /// The URL of this user's REST endpoint.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// The URL of the avatar image of the user.
        /// </summary>
        public Uri ImageUrl { get; private set; }
    }
}