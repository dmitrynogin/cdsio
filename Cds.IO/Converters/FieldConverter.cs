using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Converters
{
    public abstract class FieldConverter
    {
        static object Sync { get; } = new object();
        static IEnumerable<FieldConverter> Converters { get; set; } = new FieldConverter[]
        {
            new DefaultConverter(), new VersionConverter()
        };

        public static void Register(FieldConverter converter)
        {
            lock (Sync)
                Converters = new List<FieldConverter>(Converters) { converter };
        }

        public static object Convert(Type type, object value) =>
            Converters
                .Select(c => c.ConvertCore(type, value))
                .FirstOrDefault(v => v != null);

        protected abstract object ConvertCore(Type type, object value);
    }
}
