namespace Infinity.Models
{
    /// <summary>
    /// The version control type of a Team Project, either
    /// TFVC or Git.
    /// </summary>
    public enum VersionControlType
    {
        /// <summary>
        /// The Team Project's version control type is not known.
        /// </summary>
        Unknown,

        /// <summary>
        /// The Team Project uses Team Foundation Version Control.
        /// </summary>
        TFVC,

        /// <summary>
        /// The Team Project uses Git.
        /// </summary>
        Git
    }
}
