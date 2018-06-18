using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO
{
    public class FileBackup : IDisposable
    {
        public FileBackup(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            if(File.Exists(Path))
                File.Move(Path, Copy);
        }

        string Path { get; }
        string Copy => Path + ".bak";

        public void Delete() =>
            File.Delete(Copy);
                
        public void Dispose()
        {
            if (File.Exists(Copy))
            {
                File.Delete(Path);
                File.Move(Copy, Path);
            }
        }
    }
}
