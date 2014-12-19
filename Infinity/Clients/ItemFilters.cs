using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Clients
{
    /// <summary>
    /// Item query filters
    /// </summary>
    public class ItemFilters
    {
        /// <summary>
        /// The recursion level for queries on folders.
        /// </summary>
        public RecursionLevel RecursionLevel { get; set; }

        /// <summary>
        /// The revision of the item to query.
        /// </summary>
        public Revision Revision { get; set; }

        /// <summary>
        /// The query to perform using the Revision.
        /// </summary>
        public RevisionOptions RevisionOptions { get; set; }
    }
}