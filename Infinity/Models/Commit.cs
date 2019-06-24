using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// A commit in a Git repository.
    /// </summary>
    public class Commit
    {
        /// <summary>
        /// The commit ID.
        /// </summary>
        [JsonProperty("CommitId")]
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The parents of the commit.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public List<ObjectId> Parents { get; set; }

        /// <summary>
        /// The tree that makes up this commit.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId TreeId { get; set; }

        /// <summary>
        /// The signature of the person who placed these changes in the
        /// repository.
        /// </summary>
        public Signature Committer { get; set; }

        /// <summary>
        /// The signature of the person who authored these changes.
        /// </summary>
        public Signature Author { get; set; }

        /// <summary>
        /// The commit message.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Information about who pushed this commit.
        /// </summary>
        public PushDetails Push { get; set; }

        /// <summary>
        /// Information about the changes in this commit.
        /// </summary>
        public CommitChangeCounts ChangeCounts { get; set; }

        /// <summary>
        /// List of the changes in this commit.
        /// </summary>
        public List<CommitChange> Changes { get; set; }

        /// <summary>
        /// The URL for this commit information.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The URL to display the commit information in the web.
        /// </summary>
        public Uri RemoteUrl { get; set; }

        /// <summary>
        /// Links to REST resources.
        /// </summary>
        [JsonProperty("_links")]
        public CommitLinks Links { get; set; }    
    }
}
