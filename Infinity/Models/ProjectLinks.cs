namespace Infinity.Models
{
    /// <summary>
    /// Links to other Project resources.
    /// </summary>
    public class ProjectLinks
    {
        /// <summary>
        /// Link to the Team Project's REST API endpoint.
        /// </summary>
        public ProjectLink Self { get; private set; }

        /// <summary>
        /// Link to the Project Collection REST API endpoint.
        /// </summary>
        public ProjectLink Collection { get; private set; }

        /// <summary>
        /// Link to the web access portal for this Team Project.
        /// </summary>
        public ProjectLink Web { get; private set; }
    }
}
