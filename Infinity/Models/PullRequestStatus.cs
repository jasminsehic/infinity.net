namespace Infinity.Models
{
    /// <summary>
    /// The state of a pull request
    /// </summary>
    public enum PullRequestStatus
    {
        /// <summary>
        /// The pull request is currently open and active
        /// </summary>
        Active,

        /// <summary>
        /// The pull request has been abandoned by the author
        /// </summary>
        Abandoned,

        /// <summary>
        /// The pull request has been merged into the target branch
        /// </summary>
        Completed
    }
}
