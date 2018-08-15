using System.Collections.Generic;

namespace Cds.IO.Cones
{
    public class ConeModule
    {
        [Field] public string Name { get; set; }
        [Field("Offset, mm")] public double Offset { get; set; }
        [Field("Length, mm")] public double Length { get; set; }
        [Field("Adapter Length, mm")] public double AdapterLength { get; set; }
        [Field("Friction Reducer, mm")] public double FrictionReducer { get; set; }
        [Table] public IList<ConeChannel> Channels { get; set; }
    }
}