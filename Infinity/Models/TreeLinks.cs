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
        public LinkUrl Self { get; set; }

        /// <summary>
        /// Link to the repository's REST API endpoint.
        /// </summary>
        public LinkUrl Repository { get; set; }

        /// <summary>
        /// Links to the REST API endpoints for the entries of a tree.
        /// </summary>
        public List<LinkUrl> TreeEntries { get; set; }
    }
}