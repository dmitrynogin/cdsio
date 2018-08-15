using Cds.IO.Cones;

namespace Cds.IO
{
    public abstract class ConeFile<T> : SoundingFile<T> 
        where T : ConeFile<T>, new()
    {
        [Section] public ConeInfo Cone { get; set; }
    }
}
