namespace Infinity.Clients
{
    /// <summary>
    /// The type of revision in a Git repository.
    /// </summary>
    public enum RevisionType
    {
        /// <summary>
        /// A branch in a repository.
        /// </summary>
        Branch,

        /// <summary>
        /// A tag in a repository.
        /// </summary>
        Tag,

        /// <summary>
        /// A commit named by ID.
        /// </summary>
        Commit
    }
}
