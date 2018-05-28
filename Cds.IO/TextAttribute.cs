using System;
using System.Runtime.CompilerServices;

namespace Cds.IO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextAttribute : SectionAttribute
    {
        public TextAttribute([CallerMemberName] string name = null, [CallerLineNumber] int order = 0)
            : base(name, order)
        {
        }
    }
}
