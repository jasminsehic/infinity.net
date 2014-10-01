using System;

namespace Infinity.Models
{
    /// <summary>
    /// Information about a Team Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// The unique ID for this Team Project.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the Team Project.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The URL of the Team Project's REST endpoint.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// The state of the Team Project.
        /// </summary>
        public ProjectState State { get; private set; }
    }
}