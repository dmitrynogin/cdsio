using System.Collections.Generic;

namespace Cds.IO.Cones
{
    public class ConeInfo 
    {
        [Field("Cone ID")] public string ConeID { get; set; }
        [Field("Cone Type")] public string ConeType { get; set; }
        [Field("Net Area Ratio")] public double NetAreaRatio { get; set; }
        [Table("AD Info")] public IList<ADInfo> ADInfo { get; set; }
        [Table] public IList<ConeChannel> Channels { get; set; }
    }
}
