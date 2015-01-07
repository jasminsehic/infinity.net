using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// A reference (branch, tag, etc) in a Git repository.
    /// </summary>
    public class Reference
    {
        /// <summary>
        /// The fully-qualified name for the reference.  For branches, this
        /// will be prefixed with <code>refs/heads/</code>.  For tags, this
        /// will be prefixed with <code>refs/tags/</code>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The object ID that this reference points to.
        /// </summary>
        [JsonProperty("ObjectId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The URL of the reference's REST endpoint.
        /// </summary>
        public Uri Url { get; set; }
    }
}