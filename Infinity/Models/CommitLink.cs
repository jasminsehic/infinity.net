using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    /// <summary>
    /// A link to commit information.
    /// </summary>
    public class CommitLink
    {
        /// <summary>
        /// The ID of the commit.
        /// </summary>
        public string CommitId { get; private set; }

        /// <summary>
        /// The URL of the rest endpoint for the commit.
        /// </summary>
        public Uri Url { get; private set; }
    }
}
