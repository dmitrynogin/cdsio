using Cds.IO.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Formats.Binary
{
    static class BinaryFileWriter
    {
        public static void Write<T>(this CdsFile<T> file, BinaryWriter writer)
            where T : CdsFile<T>, new()
        {
        }
    }
}
