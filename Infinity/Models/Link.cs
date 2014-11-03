using System;

using RestSharp;
using RestSharp.Deserializers;

namespace Infinity.Models
{
    /// <summary>
    /// A link to a resource.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// The ID for this resource
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The URL for this resource's link.
        /// </summary>
        public Uri Url { get; private set; }
    }
}
