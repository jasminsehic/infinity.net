using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// A link to commit information.
    /// </summary>
    public class CommitLink
    {
        /// <summary>
        /// The ID of the commit.
        /// </summary>
        [JsonProperty("CommitId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The URL of the rest endpoint for the commit.
        /// </summary>
        public Uri Url { get; set; }
    }
}
