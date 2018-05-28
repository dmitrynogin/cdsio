using System.Collections.Generic;

namespace Cds.IO
{
    public class SoundingCoordinates
    {
        [Field("Coordinate Source")] public string CoordinateSource { get; set; }
        [Field("Coordinate System")] public string CoordinateSystem { get; set; }
        [Field("Coordinate Datum")] public string CoordinateDatum { get; set; }
        [Field("Coordinate Type")] public string CoordinateType { get; set; }
        [Field("Coordinate Units")] public string CoordinateUnits { get; set; }
        [Field("EPSG ID")] public int EpsgID { get; set; }
        [Field("UTM Zone Text")] public string UtmZoneText { get; set; }
        [Field("UTM Zone Number")] public int UtmZoneNumber { get; set; }
        [Field("Elevation Source")] public string ElevationSource { get; set; }
        [Field("Elevation Units")] public string ElevationUnits { get; set; }
        [Field("Elevation Reference")] public string ElevationReference { get; set; }
        [Text] public string Comment { get; set; }
        [Table] public IList<CoordinateData> Data { get; set; }
    }
}
