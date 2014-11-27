using System;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "CommitId")]
        public ObjectId Id { get; private set; }

        /// <summary>
        /// The URL of the rest endpoint for the commit.
        /// </summary>
        public Uri Url { get; private set; }
    }
}
