using System;
using System.Collections.Generic;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "PushId")]
        public int Id { get; private set; }

        /// <summary>
        /// The repository the changes were pushed into.
        /// </summary>
        public Repository Repository { get; private set; }

        /// <summary>
        /// The date the changes were pushed.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// The user who pushed the change.
        /// </summary>
        public Identity PushedBy { get; private set; }

        /// <summary>
        /// The reference updates this push performed.
        /// </summary>
        public List<RefUpdate> RefUpdates { get; private set; }

        /// <summary>
        /// The commits included in the push.
        /// </summary>
        public List<Commit> Commits { get; private set; }

        /// <summary>
        /// The URL of the push details.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// Links to REST resources.
        /// </summary>
        [DeserializeAs(Name = "_links")]
        public PushLinks Links { get; private set; }
    }
}
