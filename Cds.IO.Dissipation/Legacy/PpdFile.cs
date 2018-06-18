using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Legacy
{
    public static class PpdFile
    {
        public static void WritePpd(this DissipationFile file, string path)
        {
            using (var backup = new FileBackup(path))
            using(var writer = new StreamWriter(path))
            {
                writer.WritePpd(file);
                backup.Delete();
            }
        }

        static void WritePpd(this TextWriter writer, DissipationFile file)
        {
            // TODO: Implement PPD output
        }
    }
}
