using System;
using System.Collections.Generic;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "ObjectId")]
        public ObjectId Id { get; private set; }

        /// <summary>
        /// The size of the Git blob.
        /// </summary>
        public long Size { get; private set; }

        /// <summary>
        /// The URL of this blob's REST endpoint
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// Links to other blob resources.
        /// </summary>
        [DeserializeAs(Name = "_links")]
        public BlobLinks Links { get; private set; }
    }
}