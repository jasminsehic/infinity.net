using System;

namespace Infinity.Models
{
    public class Reference
    {
        public string Name { get; private set; }
        public string ObjectId { get; private set; }
        public Uri Url { get; private set; }
    }
}