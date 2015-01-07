using System;

namespace Infinity.Models
{
    /// <summary>
    /// A Git repository.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// The unique ID for this Git repository.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of this Git repository.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL of this repository's REST endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The Team Project that this Git repository is in.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// The name of the default branch for this repository.
        /// </summary>
        public string DefaultBranch { get; set; }

        /// <summary>
        /// The URL used to clone the Git repository.
        /// </summary>
        public Uri RemoteUrl { get; set; }
    }
}