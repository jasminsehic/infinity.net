using System;

using RestSharp;
using RestSharp.Deserializers;

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
        public string ObjectId { get; private set; }

        /// <summary>
        /// The name of the entry in the tree.
        /// </summary>
        public string RelativePath { get; private set; }

        /// <summary>
        /// The mode of the tree entry.
        /// </summary>
        public int Mode { get; private set; }

        /// <summary>
        /// The type of the tree entry.
        /// </summary>
        [DeserializeAs(Name = "gitObjectType")]
        public ObjectType Type { get; private set; }

        /// <summary>
        /// The URL of this tree's REST endpoint
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// The size of the tree as a serialized Git object.
        /// </summary>
        public int Size { get; private set; }
    }
}