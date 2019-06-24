namespace Infinity.Clients
{
    /// <summary>
    /// Diff filters.
    /// </summary>
    public class DiffFilters
    {
        /// <summary>
        /// The revision to diff to.
        /// </summary>
        public Revision TargetRevision { get; set; }

        /// <summary>
        /// The revision to diff from.
        /// </summary>
        public Revision BaseRevision { get; set; }

        /// <summary>
        /// The maximum number of diff items to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The number of diff items to return from the query.
        /// </summary>
        public int Skip { get; set; }
    }
}
