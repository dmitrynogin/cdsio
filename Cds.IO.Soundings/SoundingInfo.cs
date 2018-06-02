using System;

namespace Cds.IO
{
    public class SoundingInfo
    {
        [Field("Job Number")] public string JobNumber { get; set; }
        [Field] public string Client { get; set; }
        [Field] public string Project { get; set; }
        [Field] public string Location { get; set; }
        [Field("Sounding ID")] public string SoundingID { get; set; }
        [Field] public string Crew { get; set; }
        [Field("Base Filename")] public string BaseFilename { get; set; }
        [Field(Format = "yyyy-MM-dd HH:mm:ss")] public DateTime Started { get; set; }

    }
}
