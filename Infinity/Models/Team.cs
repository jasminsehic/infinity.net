using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    /// <summary>
    /// A team defined in Team Foundation Server.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The unique ID for this team
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of this team
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The URL of this team's REST endpoint
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// The description of this team
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The identity URL for this team
        /// </summary>
        public Uri IdentityUrl { get; private set; }
    }
}
