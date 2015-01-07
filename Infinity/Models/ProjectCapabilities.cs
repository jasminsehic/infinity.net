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
        public VersionControlCapabilities VersionControl { get; set; }

        /// <summary>
        /// The process template settings for a Team Project.
        /// </summary>
        public ProcessTemplateCapabilities ProcessTemplate { get; set; }
    }
}
