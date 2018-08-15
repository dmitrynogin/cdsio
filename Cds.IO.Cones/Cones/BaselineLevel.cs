namespace Cds.IO.Cones
{
    public class BaselineLevel
    {
        [Field] public string Name { get; set; }
        [Field] public double Value { get; set; }
        [Field] public string ValueUnits { get; set; }
        [Field] public double Raw { get; set; }
        [Field] public string RawUnits { get; set; }
    }
}