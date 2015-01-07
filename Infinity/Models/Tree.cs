using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Information about a Git tree.
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// The Git object ID for this tree.
        /// </summary>
        [JsonProperty("ObjectId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The URL of this tree's REST endpoint
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The entries in this tree.
        /// </summary>
        public List<TreeEntry> TreeEntries { get; set; }

        /// <summary>
        /// The size of the tree as a serialized Git object.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Links to other tree resources.
        /// </summary>
        [JsonProperty("_links")]
        public TreeLinks Links { get; set; }
    }
}