using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Differences between two commits.
    /// </summary>
    public class Diff
    {
        /// <summary>
        /// The ID of the common ancestor between the commits.
        /// </summary>
        [JsonConverter(typeof(ObjectId.JsonConverter))]
        public ObjectId CommonCommit { get; set; }

        /// <summary>
        /// The number of commits that are in the target, beyond the
        /// common ancestor.
        /// </summary>
        public int AheadCount { get; set; }

        /// <summary>
        /// The number of commits that are in the base, beyond the
        /// common ancestor.
        /// </summary>
        public int BehindCount { get; set; }

        /// <summary>
        /// Are all changes included in this result.
        /// </summary>
        public bool AllChangesIncluded { get; set; }

        /// <summary>
        /// The number of changes, by type, in this diff.
        /// </summary>
        public CommitChangeCounts ChangeCounts { get; set; }

        /// <summary>
        /// The changes in the diff.
        /// </summary>
        public List<CommitChange> Changes { get; set; }
    }
}
