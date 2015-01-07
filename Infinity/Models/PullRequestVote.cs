namespace Infinity.Models
{
    /// <summary>
    /// The voting response from a reviewer of a pull request.
    /// </summary>
    public enum PullRequestVote
    {
        /// <summary>
        /// The reviewer does not approve this pull request.
        /// </summary>
        No = -10,

        /// <summary>
        /// The reviewer has no vote on this pull request.
        /// </summary>
        None = 0,

        /// <summary>
        /// The reviewer approves this pull request.
        /// </summary>
        Yes = 10,
    }
}
