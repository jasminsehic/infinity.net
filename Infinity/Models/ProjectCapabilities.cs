using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    /// <summary>
    /// The capabilities and settings for a Team Project.
    /// </summary>
    public class ProjectCapabilities
    {
        /// <summary>
        /// The version control settings for a Team Project.
        /// </summary>
        public VersionControlCapabilities VersionControl { get; private set; }

        /// <summary>
        /// The process template settings for a Team Project.
        /// </summary>
        public ProcessTemplateCapabilities ProcessTemplate { get; private set; }
    }
}
