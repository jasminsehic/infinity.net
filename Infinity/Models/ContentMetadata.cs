using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// Metadata for an item in a Git repository.
    /// </summary>
    public class ContentMetadata
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        [JsonProperty("FileName")]
        public string Filename { get; set; }

        /// <summary>
        /// The extension of the item.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// The content type of the item.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The code page of the item.
        /// </summary>
        public int? Encoding { get; set; }
    }
}
