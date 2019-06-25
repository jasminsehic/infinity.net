namespace Infinity.Clients
{
    /// <summary>
    /// Recursion level to query
    /// </summary>
    public enum RecursionLevel
    {
        /// <summary>
        /// Do not return children
        /// </summary>
        None,

        /// <summary>
        /// Return only immediate children
        /// </summary>
        OneLevel,

        /// <summary>
        /// Return all children
        /// </summary>
        Full
    }
}
