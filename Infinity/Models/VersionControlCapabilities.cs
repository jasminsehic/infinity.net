using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Deserializers;

namespace Infinity.Models
{
    /// <summary>
    /// The version control settings for a Team Project.
    /// </summary>
    public class VersionControlCapabilities
    {
        /// <summary>
        /// The type of version control for this Team Project
        /// (TFVC or Git).
        /// </summary>
        [DeserializeAs(Name = "sourceControlType")]
        public VersionControlType VersionControlType { get; private set; }
    }
}