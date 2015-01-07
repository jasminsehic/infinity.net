using System;

namespace Infinity.Models
{
    /// <summary>
    /// The person who authored or committed a change, and the date that
    /// it was created.
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// The name of the person who authored or committed the change.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the person who authored or committed the
        /// change.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The date the change was authored or committed.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
