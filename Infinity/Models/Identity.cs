using System;

namespace Infinity.Models
{
    /// <summary>
    /// The identity of a member of a team.
    /// </summary>
    public class Identity
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The display name of the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The unique (to a collection) name for the user.
        /// </summary>
        public string UniqueName { get; set; }

        /// <summary>
        /// The URL of this user's REST endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The URL of the avatar image of the user.
        /// </summary>
        public Uri ImageUrl { get; set; }
    }
}