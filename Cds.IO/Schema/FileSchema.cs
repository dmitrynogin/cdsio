using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Schema
{
    class FileSchema
    {
        public FileSchema(object container, int level = 1)
        {
            Fields = FileField.Of(container).ToArray();
            Sections = FileSection.Of(container, level).ToArray();
        }

        public IReadOnlyList<FileField> Fields { get; }
        public IReadOnlyList<FileSection> Sections { get; }
    }
}
