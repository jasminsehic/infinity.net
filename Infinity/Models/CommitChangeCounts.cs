using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    /// <summary>
    /// Information about the files changed in a commit.
    /// </summary>
    public class CommitChangeCounts
    {
        /// <summary>
        /// Number of files added in a commit.
        /// </summary>
        public int Add { get; private set; }

        /// <summary>
        /// Number of files edited in a commit.
        /// </summary>
        public int Edit { get; private set; }

        /// <summary>
        /// Number of files deleted in a commit.
        /// </summary>
        public int Delete { get; private set; }
    }
}
