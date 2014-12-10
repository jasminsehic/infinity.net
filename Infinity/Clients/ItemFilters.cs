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
        /// Whether to include metadata about the contents.
        /// </summary>
        public bool IncludeContentMetadata { get; set; }
    }
}