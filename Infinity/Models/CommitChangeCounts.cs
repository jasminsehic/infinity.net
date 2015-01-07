namespace Infinity.Models
{
    /// <summary>
    /// Information about the files changed in a commit.
    /// </summary>
    public class CommitChangeCounts
    {
        /// <summary>
        /// Number of files added in a commit.
        /// </summary>
        public int Add { get; set; }

        /// <summary>
        /// Number of files edited in a commit.
        /// </summary>
        public int Edit { get; set; }

        /// <summary>
        /// Number of files deleted in a commit.
        /// </summary>
        public int Delete { get; set; }
    }
}
