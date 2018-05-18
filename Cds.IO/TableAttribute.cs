using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableAttribute : SectionAttribute
    {
        public TableAttribute([CallerMemberName] string name = null, [CallerLineNumber] int order = 0)
            : base(name, order)
        {
        }
    }
}
