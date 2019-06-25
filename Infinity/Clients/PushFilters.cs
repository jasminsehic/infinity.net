using System;

namespace Infinity.Clients
{
    /// <summary>
    /// Push query filters
    /// </summary>
    public class PushFilters
    {
        /// <summary>
        /// Start date to query for matching commits.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// End date to query for matching commits.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Pusher to match.
        /// </summary>
        public Guid? Pusher { get; set; }

        /// <summary>
        /// The maximum number of pushes to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The number of pushes to return from the query.
        /// </summary>
        public int Skip { get; set; }
    }
}