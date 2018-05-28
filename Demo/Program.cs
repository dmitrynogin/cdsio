using Cds.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = Sample();
            var copy = VaneFile.Parse(file.ToString());

            if (file.ToString() != copy.ToString())
                WriteLine("Oops!");
            else
                WriteLine(copy);
        }


        static VaneFile Sample()
        {
            return new VaneFile
            {
                Type = "Vane Test",
                Version = new Version(0, 1),
                Created = DateTime.Now,
                FilePath = "D:\\17-04073_VST443.vstx",
                Application = new SourceApplication
                {
                    Name = "eVane",
                    Version = new Version(0, 1),
                },

                Sounding = new SoundingInfo
                {
                    JobNumber = "17-04073",
                    Client = "Suncor",
                    Project = "2017 STP Foundation Investigation",
                    Location = "STP",
                    SoundingID = "VST17-STP-G-443",
                    Crew = "BKIR/QROB",
                    BaseFilename = "17-04073_VST443",
                    Started = DateTime.Now,
                },

                Coordinates = new SoundingCoordinates
                {
                    CoordinateSource = "ConeTec Trimble Survey (RTK)",
                    CoordinateSystem = "Suncor Steepbank",
                    CoordinateDatum = "Suncor Local",
                    CoordinateType = "Local Grid",
                    CoordinateUnits = "Metre",
                    EpsgID = 9100003,
                    UtmZoneText = "N/A",
                    UtmZoneNumber = 0,
                    ElevationSource = "ConeTec Trimble Survey (RTK)",
                    ElevationUnits = "Metre",
                    ElevationReference = "Suncor Steepbank (site specific adjustment)",
                    Comment = "N/A",
                    Data = new[]
                                {
                        new CoordinateData
                        {
                            Northing = 240245.319,
                            Easting = 151599.147,
                            Latitude = null,
                            Longitude = null,
                            SurfaceElevation = 376.934,
                            Gpgga = "$GPGGA,172640.000,4911.7306,N,12305.4756,W,1,07,1.2,18.0,M,-16.8,M,,0000*5D",
                            Gprmc = "$GPRMC,172640.000,A,4911.7306,N,12305.4756,W,0.00,151.30,200715,,,A*77",
                        }
                    }
                },
            };
        }
    }


}
