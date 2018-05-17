using Cds.IO.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Formats.Text
{
    static class TextFileWriter
    {
        public static void Write<T>(this CdsFile<T> file, TextWriter writer)            
            where T : CdsFile<T>, new()
        {
            var schema = CdsFile<T>.Schema;
            using (writer)
            {
                foreach (var f in schema.Fields)
                    writer.WriteProperty(f, file);

                foreach (var s in schema.Sections)
                    if (s.IsList)
                        writer.WriteTable(s, file);
                    else
                        writer.WriteSection(s, file);
            }
        }

        static void WriteTable(this TextWriter writer, FileSection section, object target)
        {
            writer.WriteHeader(section);
            writer.WriteColumns(section);
            foreach (var row in (IEnumerable)section[target])
                writer.WriteRow(section, row);

            writer.WriteFooter(section);
        }

        static void WriteSection(this TextWriter writer, FileSection section, object target)
        {
            writer.WriteHeader(section);
            foreach (var f in section.Schema.Fields)
                writer.WriteProperty(f, section[target]);

            foreach (var s in section.Schema.Sections)
                if (s.IsList)
                    writer.WriteTable(s, section[target]);
                else
                    writer.WriteSection(s, section[target]);

            writer.WriteFooter(section);
        }

        static void WriteHeader(this TextWriter writer, FileSection section)
        {
            writer.WriteLine();
            writer.WriteLine($"{new string('<', section.Level)} {section.Name}");
        }

        static void WriteColumns(this TextWriter writer, FileSection section) =>
            writer.WriteLine(string.Join(", ", from f in section.Schema.Fields select f.Name));

        static void WriteRow(this TextWriter writer, FileSection section, object row) =>
            writer.WriteLine(string.Join(" ", from f in section.Schema.Fields select f.Format(row)));
        
        static void WriteFooter(this TextWriter writer, FileSection section)
        {
            //writer.WriteLine();
            writer.WriteLine(new string('>', section.Level));
        }

        static void WriteProperty(this TextWriter writer, FileField field, object target) =>
            writer.WriteLine($"{field.Name}: {field.Format(target)}");
    }
}
