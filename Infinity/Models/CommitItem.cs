using System;

using RestSharp;
using RestSharp.Deserializers;

namespace Infinity.Models
{
    /// <summary>
    /// The item changed in a Git commit.
    /// </summary>
    public class CommitItem
    {
        /// <summary>
        /// The type of object changed (blob or tree).
        /// </summary>
        [DeserializeAs(Name = "gitObjectType")]
        public ObjectType Type { get; private set; }

        /// <summary>
        /// The path to the changed item.
        /// </summary>
        public string Path { get; private set; }    

        /// <summary>
        /// The URL of the REST endpoint of the changed item.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// Whether the item is a folder.
        /// </summary>
        public bool IsFolder { get; private set; }
    }
}
