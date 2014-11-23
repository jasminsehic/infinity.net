using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    /// <summary>
    /// The information from when a change was pushed.
    /// </summary>
    public class PushDetails
    {
        /// <summary>
        /// The unique ID of the push.
        /// </summary>
        public int PushId { get; private set; }

        /// <summary>
        /// The date the changes were pushed.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// The user who pushed the change.
        /// </summary>
        public TeamMember PushedBy { get; private set; }
    }
}
