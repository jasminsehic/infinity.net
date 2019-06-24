using System;

namespace Infinity.Clients
{
    /// <summary>
    /// Commit query filters
    /// </summary>
    public class CommitFilters
    {

        /// <summary>
        /// Item path to match.
        /// </summary>
        public string ItemPath { get; set; }

        /// <summary>
        /// Committer to match.
        /// </summary>
        public string Committer { get; set; }

        /// <summary>
        /// Author to match.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Start date to query for matching commits.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// End date to query for matching commits.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// The maximum number of commits to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The number of commits to return from the query.
        /// </summary>
        public int Skip { get; set; }
    }
}
