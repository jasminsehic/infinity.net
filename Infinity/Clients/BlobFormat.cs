using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Clients
{
    /// <summary>
    /// The format to download a blob as.
    /// </summary>
    public enum BlobFormat
    {
        /// <summary>
        /// Download as binary data (a byte stream).
        /// </summary>
        Raw,

        /// <summary>
        /// Download as a zip file.
        /// </summary>
        Zip
    }
}
