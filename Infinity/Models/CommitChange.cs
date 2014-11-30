
namespace Infinity.Models
{
    /// <summary>
    /// A change in a commit.
    /// </summary>
    public class CommitChange
    {
        /// <summary>
        /// The type of change (edit, delete, or add).
        /// </summary>
        public ChangeType Type { get; private set; }

        /// <summary>
        /// The item changed.
        /// </summary>
        public CommitItem Item { get; private set; }
    }
}
