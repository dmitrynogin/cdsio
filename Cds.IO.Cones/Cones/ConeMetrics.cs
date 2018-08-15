namespace Cds.IO.Cones
{
    public class ConeMetrics
    {
        [Field("Start Depth, m")] public double StartDepth { get; set; }
        [Field("Reference To Zero Depth, m")] public double ReferenceToZeroDepth { get; set; }
        [Field("Initital Stickup, m")] public double InititalStickup { get; set; }
        [Field("Drill Out, m")] public double DrillOut { get; set; }
        [Field("CasedTo, m")] public double CasedTo { get; set; }
        [Field("Rods in Rack to Start")] public int RodsInRackToStart { get; set; }
        [Field("Rods in Rack after Casing")] public int RodsInRackAfterCasing { get; set; }
        [Field("Stickup after Casing, m")] public double StickupAfterCasing { get; set; }
        [Field("Cone with Module(s) Length, m")] public double ConeWithModuleLength { get; set; }
        [Field("Depth Increment, mm")] public double DepthIncrement { get; set; }
    }
}