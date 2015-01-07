namespace Infinity.Models
{
    /// <summary>
    /// Links to other pull request resources.
    /// </summary>
    public class PullRequestLinks
    {
        /// <summary>
        /// Link to the pull request's REST API endpoint.
        /// </summary>
        public LinkUrl Self { get; set; }

        /// <summary>
        /// Link to the repository's REST API endpoint.
        /// </summary>
        public LinkUrl Repository { get; set; }

        /// <summary>
        /// Link to the work items for this Team Project.
        /// </summary>
        public LinkUrl WorkItems { get; set; }

        /// <summary>
        /// Link to the source branch's REST API endpoint.
        /// </summary>
        public LinkUrl SourceBranch { get; set; }

        /// <summary>
        /// Link to the target branch's REST API endpoint.
        /// </summary>
        public LinkUrl TargetBranch { get; set; }

        /// <summary>
        /// Link to the source branch's REST API endpoint.
        /// </summary>
        public LinkUrl SourceCommit { get; set; }

        /// <summary>
        /// Link to the target branch's REST API endpoint.
        /// </summary>
        public LinkUrl TargetCommit { get; set; }

        /// <summary>
        /// Link to the creator's REST API endpoint.
        /// </summary>
        public LinkUrl CreatedBy { get; set; }

        /// <summary>
        /// Link to the merged commit's REST API endpoint
        /// </summary>
        public LinkUrl MergeCommit { get; set; }
    }
}