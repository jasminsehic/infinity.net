using System;
using Newtonsoft.Json;

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
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the Team Project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the Team Project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the Team Project's REST endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The state of the Team Project.
        /// </summary>
        public ProjectState State { get; set; }

        /// <summary>
        /// The default team for this Team Project.
        /// </summary>
        public Team DefaultTeam { get; set; }

        /// <summary>
        /// Links to other Project resources.
        /// </summary>
        [JsonProperty("_links")]
        public ProjectLinks Links { get; set; }

        /// <summary>
        /// The settings and capabilities for this Team Project.
        /// </summary>
        public ProjectCapabilities Capabilities { get; set; }
    }
}