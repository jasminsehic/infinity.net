using System;
using System.Collections.Generic;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "ObjectId")]
        public ObjectId Id { get; private set; }

        /// <summary>
        /// The type of this item.
        /// </summary>
        [DeserializeAs(Name = "GitObjectType")]
        public ObjectType Type { get; private set; }

        /// <summary>
        /// The commit ID for this item.
        /// </summary>
        public ObjectId CommitId { get; private set; }

        /// <summary>
        /// The path for this item.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Whether this item is a folder.
        /// </summary>
        public bool IsFolder { get; private set; }

        /// <summary>
        /// The content metadata for this item.
        /// </summary>
        [DeserializeAs(Name = "ContentMetadata")]
        public ContentMetadata Metadata { get; private set; }

        /// <summary>
        /// The URL of this blob's REST endpoint
        /// </summary>
        public Uri Url { get; private set; }
    }
}