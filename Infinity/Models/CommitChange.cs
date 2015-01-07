using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// A change in a commit.
    /// </summary>
    public class CommitChange
    {
        /// <summary>
        /// The type of change (edit, delete, or add).
        /// </summary>
        [JsonProperty("changeType")]
        public ChangeType Type { get; set; }

        /// <summary>
        /// The item changed.
        /// </summary>
        public CommitItem Item { get; set; }
    }
}
