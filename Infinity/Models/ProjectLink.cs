using System;

using RestSharp;
using RestSharp.Deserializers;

namespace Infinity.Models
{
    /// <summary>
    /// A link to a project resource.
    /// </summary>
    public class ProjectLink
    {
        /// <summary>
        /// The URL for this project's link.
        /// </summary>
        [DeserializeAs(Name = "href")]
        public Uri Url { get; private set; }
    }
}
