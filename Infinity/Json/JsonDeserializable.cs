using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Json
{
    /// <summary>
    /// Attribute that indicates that the type can be constructed with
    /// a public constructor with a string argument.
    /// </summary>
    public class JsonDeserializable : Attribute
    {
    }
}
