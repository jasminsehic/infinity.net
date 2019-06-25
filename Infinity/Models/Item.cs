using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Information about an item in a Git repository.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The Git object ID for this item.
        /// </summary>
        [JsonProperty("ObjectId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The type of this item.
        /// </summary>
        [JsonProperty("GitObjectType")]
        public ObjectType Type { get; set; }

        /// <summary>
        /// The commit ID for this item.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId CommitId { get; set; }

        /// <summary>
        /// The path for this item.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Whether this item is a folder.
        /// </summary>
        public bool IsFolder { get; set; }

        /// <summary>
        /// The content metadata for this item.
        /// </summary>
        [JsonProperty("ContentMetadata")]
        public ContentMetadata Metadata { get; set; }

        /// <summary>
        /// The URL of this blob's REST endpoint
        /// </summary>
        public Uri Url { get; set; }
    }
}
