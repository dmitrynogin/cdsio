using System;

namespace Cds.IO
{
    public class SourceApplication
    {
        [Field] public string Name { get; set; }
        [Field] public Version Version { get; set; }
        [Field(Format = "yyyy-MM-dd HH:mm:ss")] public DateTime Released { get; set; }
    }
}
