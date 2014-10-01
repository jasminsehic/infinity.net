namespace Infinity.Models
{
    /// <summary>
    /// The state of the Team Project.
    /// </summary>
    public enum ProjectState
    {
        /// <summary>
        /// The Team Project is operational.
        /// </summary>
        WellFormed,

        /// <summary>
        /// The Team Project is being created.
        /// </summary>
        CreatePending,

        /// <summary>
        /// The Team Project is being deleted.
        /// </summary>
        Deleting,

        /// <summary>
        /// The Team Project is new.
        /// </summary>
        New,

        /// <summary>
        /// All Team Projects should be queried.
        /// </summary>
        All
    }
}