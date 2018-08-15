namespace Cds.IO.Cones
{
    public class ConeChannel
    {
        [Field] public string Name { get; set; }
        [Field] public double? Capacity { get; set; }
        [Field] public string CapacityUnits { get; set; }
        [Field] public double Offset { get; set; }
        [Field] public string OffsetUnits { get; set; }
        [Field] public double? Area { get; set; }
        [Field] public string AreaUnits { get; set; }
        [Field] public int SensorOffset { get; set; }
        [Field] public string SensorOffsetUnits { get; set; }
    }
}
