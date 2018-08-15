using System;

namespace Cds.IO
{
    public class CoordinateData
    {
        [Field(Format = "yyyy-MM-dd HH:mm:ss")] public DateTime Captured { get; set; }
        [Field] public double? Northing { get; set; }
        [Field] public double? Easting { get; set; }
        [Field] public double? Latitude { get; set; }
        [Field] public double? Longitude { get; set; }
        [Field("Surface Elevation")] public double? SurfaceElevation { get; set; }

        [Field("GPGGA")] public string Gpgga { get; set; }
        [Field("GPRMC")] public string Gprmc { get; set; }
    }
}
