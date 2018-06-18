using System;

namespace Cds.IO
{
    public class DissipationData
    {
        [Field(Format = @"hh\:mm\:ss")] public TimeSpan Duration { get; set; }

        [Field("Duration (s)")] public double Seconds
        {
            get => Duration.TotalSeconds;
            set => Duration = TimeSpan.FromSeconds(value);
        }

        [Field("u (m)")] public double WaterHeadMeter { get; set; }

        [Field("u (ft)")] public double WaterHeadFoot
        {
            get => WaterHeadMeter / 0.3048;
            set => WaterHeadMeter = value * 0.3048;
        }

        public double PoundPerSquareInch
        {
            get => WaterHeadMeter * 1.4219702063247;
            set => WaterHeadMeter = value / 1.4219702063247;
        }

        public double Kilopascal
        {
            get => WaterHeadMeter / 0.10199773339984;
            set => WaterHeadMeter = value * 0.10199773339984;
        }

        [Field("T (V)")] public double? Volt { get; set; } 

        [Field("T (C°)")] public double? Celsius { get; set; }
    }
}
