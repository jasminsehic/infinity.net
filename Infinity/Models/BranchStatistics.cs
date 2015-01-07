namespace Infinity.Models
{
    /// <summary>
    /// Statistics for a branch.
    /// </summary>
    public class BranchStatistics
    {
        /// <summary>
        /// The name of this branch.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The commit at the tip of this branch.
        /// </summary>
        public Commit Commit { get; set; }

        /// <summary>
        /// The number of commits this branch is "ahead" of the default
        /// branch.
        /// </summary>
        public int AheadCount { get; set; }

        /// <summary>
        /// The number of commits this branch is "behind" the default
        /// branch.
        /// </summary>
        public int BehindCount { get; set; }

        /// <summary>
        /// Determines if this branch is the default branch.
        /// </summary>
        public bool IsBaseVersion { get; set; }
    }
}