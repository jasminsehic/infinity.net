using System;

namespace Infinity.Models
{
    public class Repository
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Uri Url { get; private set; }
        public Project Project { get; private set; }
        public string DefaultBranch { get; private set; }
        public Uri RemoteUrl { get; private set; }
    }
}