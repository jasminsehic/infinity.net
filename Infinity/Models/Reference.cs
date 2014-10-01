using System;

namespace Infinity.Models
{
    /// <summary>
    /// A reference (branch, tag, etc) in a Git repository.
    /// </summary>
    public class Reference
    {
        /// <summary>
        /// The fully-qualified name for the reference.  For branches, this
        /// will be prefixed with <code>refs/heads/</code>.  For tags, this
        /// will be prefixed with <code>refs/tags/</code>.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The object ID that this reference points to.
        /// </summary>
        public string ObjectId { get; private set; }

        /// <summary>
        /// The URL of the reference's REST endpoint.
        /// </summary>
        public Uri Url { get; private set; }
    }
}