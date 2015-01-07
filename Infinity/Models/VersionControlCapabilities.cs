using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// The version control settings for a Team Project.
    /// </summary>
    public class VersionControlCapabilities
    {
        /// <summary>
        /// The type of version control for this Team Project
        /// (TFVC or Git).
        /// </summary>
        [JsonProperty("sourceControlType")]
        public VersionControlType VersionControlType { get; set; }
    }
}