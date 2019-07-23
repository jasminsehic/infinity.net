namespace Infinity.Models
{
    /// <summary>
    /// The representation of a tag definition which is sent across the wire.
    /// </summary>
    public class WebApiTagDefinition
    {
        /// <summary>
        /// Whether or not the tag definition is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ID of the tag definition.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the tag definition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Resource URL for the Tag Definition.
        /// </summary>
        public string Url { get; set; }
    }
}