using Cds.IO.Cones;
using System.Collections.Generic;

namespace Cds.IO
{
    public abstract class ConeFile<T> : SoundingFile<T> 
        where T : ConeFile<T>, new()
    {
        [Section] public ConeInfo Cone { get; set; }
        [Section] public IList<ConeModule> Modules { get; set; }
        [Section] public IList<ConeBaseline> Baselines { get; set; }
    }
}
