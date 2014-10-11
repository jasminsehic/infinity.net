using System.Collections.Generic;

namespace Infinity.Models
{
    /// <summary>
    /// Links to other Git tree resources.
    /// </summary>
    public class TreeLinks
    {
        /// <summary>
        /// Link to the Git tree's REST API endpoint.
        /// </summary>
        public Link Self { get; private set; }

        /// <summary>
        /// Link to the repository's REST API endpoint.
        /// </summary>
        public Link Repository { get; private set; }

        /// <summary>
        /// Links to the REST API endpoints for the entries of a tree.
        /// </summary>
        public List<Link> TreeEntries { get; private set; }
    }
}