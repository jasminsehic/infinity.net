using Infinity.Models;

namespace Infinity.Clients
{
    /// <summary>
    /// A revision in a Git repository:  a branch, a tag or a commit.
    /// </summary>
    public class Revision
    {
        private RevisionType type;
        private string version;

        /// <summary>
        /// A revision in a Git repository, by the fully-qualified reference
        /// name or the commit ID.
        /// </summary>
        /// <param name="refNameOrCommitId">The reference name or commit ID</param>
        public Revision(string refNameOrCommitId)
        {
            if (refNameOrCommitId.StartsWith("refs/heads/"))
            {
                type = RevisionType.Branch;
                version = refNameOrCommitId.Substring(11);
            }
            else if (refNameOrCommitId.StartsWith("refs/tags/"))
            {
                type = RevisionType.Tag;
                version = refNameOrCommitId.Substring(10);
            }
            else
            {
                type = RevisionType.Commit;
                version = new ObjectId(refNameOrCommitId).ToString();
            }
        }

        /// <summary>
        /// A revision in a Git repository, by the commit ID.
        /// </summary>
        /// <param name="commitId"></param>
        public Revision(ObjectId commitId)
        {
            type = RevisionType.Commit;
            version = commitId.ToString();
        }

        internal RevisionType Type
        {
            get
            {
                return type;
            }
        }

        internal string Version
        {
            get
            {
                return version;
            }
        }

        internal object GetProperties()
        {
            return new
            {
                versionType = type.ToString().ToLowerInvariant(),
                version = version
            };
        }
    }
}
