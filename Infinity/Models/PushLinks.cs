namespace Infinity.Models
{
    /// <summary>
    /// Links to other Git push resources.
    /// </summary>
    public class PushLinks
    {
        /// <summary>
        /// Link to the push's REST API endpoint.
        /// </summary>
        public LinkUrl Self { get; set; }

        /// <summary>
        /// Link to the repository's REST API endpoint.
        /// </summary>
        public LinkUrl Repository { get; set; }

        /// <summary>
        /// Link to the pusher's REST API endpoint.
        /// </summary>
        public LinkUrl Pusher { get; set; }

        /// <summary>
        /// Links to the REST API endpoints for the commits of a push.
        /// </summary>
        public LinkUrl Commits { get; set; }

        /// <summary>
        /// Links to the REST API endpoints for the references.
        /// </summary>
        public LinkUrl Refs { get; set; }
    }
}