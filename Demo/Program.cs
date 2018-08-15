using Cds.IO;
using Cds.IO.Cones;
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
            var copy = RawConeFile.Parse(file.ToString());

            if (file.ToString() != copy.ToString())
                WriteLine("Oops!");
            else
                WriteLine(copy);
        }


        static RawConeFile Sample()
        {
            return new RawConeFile
            {
                Type = "Raw Cone File",
                Version = new Version(0, 1),
                Created = DateTime.Now,
                Completed = DateTime.Now,
                FilePath = "D:\\Cone Data\\18-04073_CP01.cone.raw",
                Application = new SourceApplication
                {
                    Name = "ConeSkan",
                    Version = new Version(0, 1, 0),
                    Released = DateTime.Now
                },
                System = new SystemInfo
                {
                    WinOSVersion = "Win 7",
                    ComputerType = "Tough Book",
                    ComputerAssetID = "J01-193",
                    DASType = "Blue Box",
                    DASAssetID = "GB01-017"
                },
                Sounding = new SoundingInfo
                {
                    JobNumber = "18-04073",
                    Client = "Suncor",
                    Project = "2018 STP Foundation Investigation",
                    Location = "STP",
                    SoundingID = "CPT18-01",     
                    Crew = "BKIR/QROB",
                    Oversight = "JGRG",
                    BaseFilename = "18-04073_CP01",
                    Started = DateTime.Now,
                },
                DeploymentEquipment = new DeploymentEquipment
                {
                    RigName = "M5T",
                    RigAssetId = "C05-005"
                },
                Coordinates = new[] 
                {
                    new SoundingCoordinates
                    {
                        Captured = DateTime.Now,
                        CoordinateSource = "ConeTec Trimble Survey (RTK)",
                        CoordinateSystem = "Suncor Steepbank",
                        CoordinateDatum = "Suncor Local",
                        CoordinateType = "Local Grid",
                        CoordinateUnits = "Meter",
                        EpsgID = 9100003,
                        UtmZoneText = "N/A",
                        UtmZoneNumber = 0,
                        ElevationSource = "ConeTec Trimble Survey (RTK)",
                        ElevationUnits = "Meter",
                        ElevationReference = "Suncor Steepbank (site specific adjustment)",
                        Comment = "N/A",
                        Data = new[]
                        {
                            new CoordinateData
                            {
                                Captured = DateTime.Now,
                                Northing = 240245.319,
                                Easting = 151599.147,
                                Latitude = null,
                                Longitude = null,
                                SurfaceElevation = 376.934,
                                Gpgga = "$GPGGA,172640.000,4911.7306,N,12305.4756,W,1,07,1.2,18.0,M,-16.8,M,,0000*5D",
                                Gprmc = "$GPRMC,172640.000,A,4911.7306,N,12305.4756,W,0.00,151.30,200715,,,A*77",
                            },
                            new CoordinateData
                            {
                                Captured = DateTime.Now,
                                Northing = 240245.123,
                                Easting = 151599.567,
                                Latitude = null,
                                Longitude = null,
                                SurfaceElevation = 376.935,
                                Gpgga = "$GPGGA,172640.000,4911.7306,N,12305.4756,W,1,07,1.2,18.0,M,-16.8,M,,0000*5D",
                                Gprmc = "$GPRMC,172640.000,A,4911.7306,N,12305.4756,W,0.00,151.30,200715,,,A*77",
                            }
                        }
                    }
                },                
                Cone = new ConeInfo
                {
                    ConeID = "AD329",
                    ConeType = "A15-T1500-F15-U500",
                    NetAreaRatio = 0.8,
                    SaturationFluid = "Silicon Oil",
                    ADInfo = new []
                    {
                        new ADInfo
                        {
                            Type = "DT9804(02)",
                            Resolution = 16
                        }
                    },
                    Metrics = new ConeMetrics
                    {
                        DepthIncrement = 25
                    }
                },
                Modules = new[]
                {
                    new ConeModule
                    {
                        Name = "Cone",
                        Offset = 0,
                        Length = 600,
                        FrictionReducer = 0,
                        Channels = new []
                        {
                            new ConeChannel
                            {
                                Name = "qc",
                                Capacity = 1500,
                                CapacityUnits ="bar",
                                Offset = 0,
                                OffsetUnits = "mm",
                                Area = 15,
                                AreaUnits = "cm2",
                                SensorOffset = 0,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "fs",
                                Capacity = 15,
                                CapacityUnits ="bar",
                                Offset = 100,
                                OffsetUnits = "mm",
                                Area = 225,
                                AreaUnits = "cm2",
                                SensorOffset = 100,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "u2",
                                Capacity = 350,
                                CapacityUnits ="kPa",
                                Offset = 0,
                                OffsetUnits = "mm",
                                SensorOffset = 0,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "Sx",
                                Offset = 200,
                                OffsetUnits = "mm",
                                SensorOffset = 200,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "Sz",
                                Offset = 200,
                                OffsetUnits = "mm",
                                SensorOffset = 200,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "Temp",
                                Offset = 0,
                                OffsetUnits = "mm",
                                SensorOffset = 0,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "InclX",
                                Capacity = 30,
                                CapacityUnits = "deg",
                                Offset = 200,
                                OffsetUnits = "mm",
                                SensorOffset = 200,
                                SensorOffsetUnits = "mm",
                            },
                            new ConeChannel
                            {
                                Name = "InclY",
                                Capacity = 30,
                                CapacityUnits = "deg",
                                Offset = 200,
                                OffsetUnits = "mm",
                                SensorOffset = 200,
                                SensorOffsetUnits = "mm",
                            }
                        }
                    },
                    new ConeModule
                    {
                        Name = "Resistivity Module",
                        Offset = 650,
                        Length = 250,
                        AdapterLength = 50,
                        Channels = new []
                        {
                            new ConeChannel
                            {
                                Name = "R",
                                Capacity = null,
                                CapacityUnits ="Ohm-m",
                                SensorOffset = 200,
                                SensorOffsetUnits = "mm",
                                Offset = 850,
                                OffsetUnits = "mm"
                            }
                        }
                    },
                },
                Baselines = new []
                {
                    new ConeBaseline
                    {
                        Name = "Initial Bluebox",
                        Time = DateTime.Now,
                        Levels = new [] 
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Initial Computer",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Final Bluebox",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Final Computer",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Initial Delta",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Final Delta",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Computer Delta",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    },
                    new ConeBaseline
                    {
                        Name = "Bluebox Delta",
                        Time = DateTime.Now,
                        Levels = new []
                        {
                            new BaselineLevel
                            {
                                Name = "qc",
                                Value = -0.5100, ValueUnits = "V",
                                Raw = -0.5100, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "ft",
                                Value = -0.5101, ValueUnits = "V",
                                Raw = -0.5101, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "u2",
                                Value = -0.5102, ValueUnits = "V",
                                Raw = -0.5102, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "Temp",
                                Value = 2.576, ValueUnits = "V",
                                Raw = 2.567, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclX",
                                Value = 0.123, ValueUnits = "V",
                                Raw = 0.123, RawUnits = "V"
                            },
                            new BaselineLevel
                            {
                                Name = "InclY",
                                Value = 0.245, ValueUnits = "V",
                                Raw = 0.254, RawUnits = "V"
                            }
                        }
                    }
                }
            };
        }
    }


}
