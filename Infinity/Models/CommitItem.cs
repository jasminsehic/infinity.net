using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// The item changed in a Git commit.
    /// </summary>
    public class CommitItem
    {
        /// <summary>
        /// The type of object changed (blob or tree).
        /// </summary>
        [JsonProperty("gitObjectType")]
        public ObjectType Type { get; set; }

        /// <summary>
        /// Whether the item is a folder.
        /// </summary>
        public bool IsFolder { get; set; }

        /// <summary>
        /// The path to the changed item.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The commit ID that changed this item.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId CommitId { get; set; }

        /// <summary>
        /// The URL of the REST endpoint of the changed item.
        /// </summary>
        public Uri Url { get; set; }
    }
}
