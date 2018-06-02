using System;

namespace Cds.IO.Converters
{
    class VersionConverter : FieldConverter
    {
        protected override object ConvertCore(Type type, object value) =>
            type == typeof(Version) && value != null
            ? Version.Parse(value.ToString())
            : null;
    }
}
