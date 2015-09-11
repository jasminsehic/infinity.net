namespace Infinity.Models
{
    /// <summary>
    /// The type of entry in a Git tree.
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// An invalid object type
        /// </summary>
        Invalid,

        /// <summary>
        /// A tree.
        /// </summary>
        Tree,

        /// <summary>
        /// A blob.
        /// </summary>
        Blob,

        /// <summary>
        /// A commit (submodule).
        /// </summary>
        Commit,
    }
}