using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO
{
    public class DissipationFile : SoundingFile<DissipationFile>
    {
        [Table] public IList<DissipationData> Data { get; set; } = new List<DissipationData>();
    }
}
