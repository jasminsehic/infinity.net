using System;

namespace Infinity.Models
{
    /// <summary>
    /// Information about reference updates.
    /// </summary>
    public class RefUpdate
    {
        /// <summary>
        /// The name of the reference that was updated.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The repository ID that contained the push.
        /// </summary>
        public Guid RepositoryId { get; private set; }

        /// <summary>
        /// The object ID before the push.
        /// </summary>
        public ObjectId OldObjectId { get; private set; }

        /// <summary>
        /// The object ID after the push.
        /// </summary>
        public ObjectId NewObjectId { get; private set; }
    }
}
