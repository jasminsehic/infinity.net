using System;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "href")]
        public Uri Url { get; private set; }
    }
}