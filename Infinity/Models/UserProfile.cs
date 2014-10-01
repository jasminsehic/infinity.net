using System;

namespace Infinity.Models
{
    /// <summary>
    /// The profile of a user in a Project Collection.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// The unique ID of the user.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The revision number for changes to the user profile.
        /// </summary>
        public int Revision { get; private set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// The unique ID of the user.
        /// </summary>
        public Guid PublicAlias { get; private set; }

        /// <summary>
        /// The email address of the user.
        /// </summary>
        public string EmailAddress { get; private set; }

        /// <summary>
        /// The revision number for changes to the user profile.
        /// </summary>
        public int CoreRevision { get; private set; }

        /// <summary>
        /// The time of the last update to the profile.
        /// </summary>
        public DateTime TimeStamp { get; private set; }
    }
}