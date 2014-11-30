using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    /// <summary>
    /// The type of change to a file in a commit.
    /// </summary>
    public enum ChangeType
    {
        /// <summary>
        /// An added file.
        /// </summary>
        Add,

        /// <summary>
        /// An edited file.
        /// </summary>
        Edit,

        /// <summary>
        /// A deleted file.
        /// </summary>
        Delete
    }
}
