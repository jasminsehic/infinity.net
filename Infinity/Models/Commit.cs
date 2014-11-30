using System;
using System.Collections.Generic;

using RestSharp;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name = "CommitId")]
        public ObjectId Id { get; private set; }

        /// <summary>
        /// The parents of the commit.
        /// </summary>
        public List<ObjectId> Parents { get; private set; }

        /// <summary>
        /// The tree that makes up this commit.
        /// </summary>
        public ObjectId TreeId { get; private set; }

        /// <summary>
        /// The signature of the person who placed these changes in the
        /// repository.
        /// </summary>
        public Signature Committer { get; private set; }

        /// <summary>
        /// The signature of the person who authored these changes.
        /// </summary>
        public Signature Author { get; private set; }

        /// <summary>
        /// The commit message.
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// Information about who pushed this commit.
        /// </summary>
        public PushDetails Push { get; private set; }

        /// <summary>
        /// Information about the changes in this commit.
        /// </summary>
        public CommitChangeCounts ChangeCounts { get; private set; }

        /// <summary>
        /// List of the changes in this commit.
        /// </summary>
        public List<CommitChange> Changes { get; private set; }

        /// <summary>
        /// The URL for this commit information.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// The URL to display the commit information in the web.
        /// </summary>
        public Uri RemoteUrl { get; private set; }

        /// <summary>
        /// Links to REST resources.
        /// </summary>
        [DeserializeAs(Name = "_links")]
        public CommitLinks Links { get; private set; }    
    }
}
