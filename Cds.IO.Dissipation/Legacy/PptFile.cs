using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Legacy
{
    public static class PptFile
    {
        public static void WritePpt(this DissipationFile file, string path)
        {
            using (var backup = new FileBackup(path))
            using (var writer = new StreamWriter(path))
            {
                writer.WritePpt(file);
                backup.Delete();
            }
        }

        static void WritePpt(this TextWriter writer, DissipationFile file)
        {
            // TODO: Implement PPT output
        }
    }
}
