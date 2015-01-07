using System;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Information about reference updates.
    /// </summary>
    public class RefUpdate
    {
        /// <summary>
        /// The name of the reference that was updated.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The repository ID that contained the push.
        /// </summary>
        public Guid RepositoryId { get; set; }

        /// <summary>
        /// The object ID before the push.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId OldObjectId { get; set; }

        /// <summary>
        /// The object ID after the push.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId NewObjectId { get; set; }
    }
}
