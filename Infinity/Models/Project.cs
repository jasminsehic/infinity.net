using System;

namespace Infinity.Models
{
    public class Project
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Uri Url { get; private set; }

        /// <summary>
        /// The state of the Team Project.
        /// </summary>
        public ProjectState State { get; private set; }
    }
}