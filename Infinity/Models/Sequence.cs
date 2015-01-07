using System.Collections.Generic;

namespace Infinity.Models
{
    internal class Sequence<T>
    {
        public int Count { get; set; }
        public List<T> Value { get; set; }
    }
}
