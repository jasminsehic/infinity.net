namespace Infinity.Models
{
    /// <summary>
    /// The status of merging the source and target branches
    /// </summary>
    public enum PullRequestMergeStatus
    {
        /// <summary>
        /// The merge status is not yet known, the merge is being performed.
        /// </summary>
        Queued,

        /// <summary>
        /// The merge did not complete successfully as there were conflicts
        /// that could not be automerged.
        /// </summary>
        Conflicts,

        /// <summary>
        /// The merge completed successfully without conflicts.
        /// </summary>
        Succeeded,

        /// <summary>
        /// The source and target could not be automerged; the contents of
        /// the source or target were too large to analyze.
        /// </summary>
        RejectedByPolicy,

        /// <summary>
        /// An unknown failure occurred.
        /// </summary>
        Failure
    }
}