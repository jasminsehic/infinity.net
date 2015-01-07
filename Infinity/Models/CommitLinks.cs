namespace Infinity.Models
{
    /// <summary>
    /// Links to other Commit resources.
    /// </summary>
    public class CommitLinks
    {
        /// <summary>
        /// Link to the Team Project's REST API endpoint.
        /// </summary>
        public LinkUrl Self { get; set; }

        /// <summary>
        /// Link to the Git Repository REST API endpoint.
        /// </summary>
        public LinkUrl Repository { get; set; }

        /// <summary>
        /// Link to the Git Repository's changes REST API endpoint.
        /// </summary>
        public LinkUrl Changes { get; set; }

        /// <summary>
        /// Link to the Git Tree's REST API endpoint.
        /// </summary>
        public LinkUrl Tree { get; set; }

        /// <summary>
        /// Link to the web access portal for this Team Project.
        /// </summary>
        public LinkUrl Web { get; set; }
    }
}
