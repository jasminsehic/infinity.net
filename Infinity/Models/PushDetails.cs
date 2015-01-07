using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// The information from when a change was pushed.
    /// </summary>
    public class PushDetails
    {
        /// <summary>
        /// The unique ID of the push.
        /// </summary>
        [JsonProperty("PushId")]
        public int Id { get; set; }

        /// <summary>
        /// The repository the changes were pushed into.
        /// </summary>
        public Repository Repository { get; set; }

        /// <summary>
        /// The date the changes were pushed.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The user who pushed the change.
        /// </summary>
        public Identity PushedBy { get; set; }

        /// <summary>
        /// The reference updates this push performed.
        /// </summary>
        public List<RefUpdate> RefUpdates { get; set; }

        /// <summary>
        /// The commits included in the push.
        /// </summary>
        public List<Commit> Commits { get; set; }

        /// <summary>
        /// The URL of the push details.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Links to REST resources.
        /// </summary>
        [JsonProperty("_links")]
        public PushLinks Links { get; set; }
    }
}
