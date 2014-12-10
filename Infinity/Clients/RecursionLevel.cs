using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Clients
{
    /// <summary>
    /// Recursion level to query
    /// </summary>
    public enum RecursionLevel
    {
        /// <summary>
        /// Do not return children
        /// </summary>
        None,

        /// <summary>
        /// Return only immediate children
        /// </summary>
        OneLevel,

        /// <summary>
        /// Return all children
        /// </summary>
        Full
    }
}
