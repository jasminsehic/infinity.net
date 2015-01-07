using System;

namespace Infinity.Models
{
    /// <summary>
    /// A team defined in Team Foundation Server.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The unique ID for this team
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of this team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL of this team's REST endpoint
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The description of this team
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The identity URL for this team
        /// </summary>
        public Uri IdentityUrl { get; set; }
    }
}
