using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Information about a Git blob.
    /// </summary>
    public class Blob
    {
        /// <summary>
        /// The Git object ID for this blob.
        /// </summary>
        [JsonProperty("ObjectId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The size of the Git blob.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The URL of this blob's REST endpoint
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Links to other blob resources.
        /// </summary>
        [JsonProperty("_links")]
        public BlobLinks Links { get; set; }
    }
}
