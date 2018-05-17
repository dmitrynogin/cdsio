using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Schema
{
    class FileSchema
    {
        public FileSchema(Type type, int level = 3)
        {
            Fields = FileField.Of(type).ToArray();
            Sections = FileSection.Of(type, level).ToArray();
        }

        public IReadOnlyList<FileField> Fields { get; }
        public IReadOnlyList<FileSection> Sections { get; }
    }
}
