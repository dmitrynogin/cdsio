using System;
using System.Collections.Generic;

namespace Cds.IO.Cones
{
    public class ConeBaseline
    {
        [Field] public string Name { get; set; }
        [Field] public DateTime Time { get; set; }
        [Table] public IList<BaselineLevel> Levels { get; set; }
    }
}