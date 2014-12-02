using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ObjectId CommonCommit { get; private set; }

        /// <summary>
        /// The number of commits that are in the target, beyond the
        /// common ancestor.
        /// </summary>
        public int AheadCount { get; private set; }

        /// <summary>
        /// The number of commits that are in the base, beyond the
        /// common ancestor.
        /// </summary>
        public int BehindCount { get; private set; }

        /// <summary>
        /// Are all changes included in this result.
        /// </summary>
        public bool AllChangesIncluded { get; private set; }

        /// <summary>
        /// The number of changes, by type, in this diff.
        /// </summary>
        public CommitChangeCounts ChangeCounts { get; private set; }

        /// <summary>
        /// The changes in the diff.
        /// </summary>
        public List<CommitChange> Changes { get; private set; }
    }
}
