using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// A link to a resource.
    /// </summary>
    public class LinkUrl
    {
        /// <summary>
        /// The URL for this resource's link.
        /// </summary>
        [JsonProperty("href")]
        public Uri Url { get; private set; }
    }
}