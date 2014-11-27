using System;
using System.Collections.Generic;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "ObjectId")]
        public ObjectId Id { get; private set; }

        /// <summary>
        /// The URL of this tree's REST endpoint
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// The entries in this tree.
        /// </summary>
        public List<TreeEntry> TreeEntries { get; private set; }

        /// <summary>
        /// The size of the tree as a serialized Git object.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Links to other tree resources.
        /// </summary>
        [DeserializeAs(Name = "_links")]
        public TreeLinks Links { get; private set; }
    }
}