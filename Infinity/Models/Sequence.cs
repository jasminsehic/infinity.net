using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models
{
    internal class Sequence<T>
    {
        public int Count { get; set; }
        public List<T> Value { get; set; }
    }
}
