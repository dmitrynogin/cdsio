using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute([CallerMemberName] string name=null, [CallerLineNumber]int order = 0)
        {
            Name = name;
            Order = order;
        }

        public string Name { get; }
        public int Order { get; }
        public string Format { get; set; } = "";
    }
}
