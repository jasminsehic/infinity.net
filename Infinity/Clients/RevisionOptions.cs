namespace Infinity.Clients
{
    /// <summary>
    /// The query to perform against the given revision.
    /// </summary>
    public enum RevisionOptions
    {
        /// <summary>
        /// None; return the specified revision.
        /// </summary>
        None,

        /// <summary>
        /// Return the first parent of the specified revision.
        /// </summary>
        FirstParent,

        /// <summary>
        /// Return the previous change of the specified revision.
        /// </summary>
        PreviousChange
    }
}
