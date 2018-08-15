using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO
{
    public abstract class SoundingFile<T> : AppFile<T>
        where T : SoundingFile<T>, new()
    {
        [Section] public SoundingInfo Sounding { get; set; }
        [Section("Deployment Equipment")] public DeploymentEquipment DeploymentEquipment { get; set; }
        [Section] public IList<SoundingCoordinates> Coordinates { get; set; }
    }
}
