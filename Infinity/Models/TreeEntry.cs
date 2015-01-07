using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Information about an entry in a Git tree.
    /// </summary>
    public class TreeEntry
    {
        /// <summary>
        /// The Git object ID for this tree entry.
        /// </summary>
        [JsonProperty("ObjectId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The name of the entry in the tree.
        /// </summary>
        public string RelativePath { get; set; }

        /// <summary>
        /// The mode of the tree entry.
        /// </summary>
        public int Mode { get; set; }

        /// <summary>
        /// The type of the tree entry.
        /// </summary>
        [JsonProperty("gitObjectType")]
        public ObjectType Type { get; set; }

        /// <summary>
        /// The URL of this tree's REST endpoint
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The size of the tree as a serialized Git object.
        /// </summary>
        public int Size { get; set; }
    }
}