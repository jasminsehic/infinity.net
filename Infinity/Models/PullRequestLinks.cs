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
        public LinkUrl Self { get; private set; }

        /// <summary>
        /// Link to the repository's REST API endpoint.
        /// </summary>
        public LinkUrl Repository { get; private set; }

        /// <summary>
        /// Link to the work items for this Team Project.
        /// </summary>
        public LinkUrl WorkItems { get; private set; }

        /// <summary>
        /// Link to the source branch's REST API endpoint.
        /// </summary>
        public LinkUrl SourceBranch { get; private set; }

        /// <summary>
        /// Link to the target branch's REST API endpoint.
        /// </summary>
        public LinkUrl TargetBranch { get; private set; }

        /// <summary>
        /// Link to the source branch's REST API endpoint.
        /// </summary>
        public LinkUrl SourceCommit { get; private set; }

        /// <summary>
        /// Link to the target branch's REST API endpoint.
        /// </summary>
        public LinkUrl TargetCommit { get; private set; }

        /// <summary>
        /// Link to the creator's REST API endpoint.
        /// </summary>
        public LinkUrl CreatedBy { get; private set; }
    }
}