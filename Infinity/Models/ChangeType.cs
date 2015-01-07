namespace Infinity.Models
{
    /// <summary>
    /// The type of change to a file in a commit.
    /// </summary>
    public enum ChangeType
    {
        /// <summary>
        /// Invalid change type.
        /// </summary>
        Invalid,

        /// <summary>
        /// An added file.
        /// </summary>
        Add,

        /// <summary>
        /// An edited file.
        /// </summary>
        Edit,

        /// <summary>
        /// A deleted file.
        /// </summary>
        Delete
    }
}
