using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO
{
    public abstract class AppFile<T> : CdsFile<T>
        where T : AppFile<T>, new()
    {
        [Field] public string Type { get; set; }
        [Field] public Version Version { get; set; }
        [Field(Format = "yyyy-MM-dd HH:mm:ss")] public DateTime Created { get; set; }
        [Field] public string FilePath { get; set; }
        [Section] public SourceApplication Application { get; set; }
    }
}
