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
        public static void Write(this FileSchema schema, TextWriter writer) 
        {
            using (writer)
            {
                foreach (var f in schema.Fields)
                    writer.WriteProperty(f);

                foreach (var s in schema.Sections)
                    if (s.IsList)
                        writer.WriteTable(s);
                    else
                        writer.WriteSection(s);
            }
        }

        static void WriteTable(this TextWriter writer, FileSection section)
        {
            writer.WriteHeader(section);
            writer.WriteColumns(section);
            foreach (var row in section.List)
                writer.WriteRow(section, row);

            writer.WriteFooter(section);
        }

        static void WriteSection(this TextWriter writer, FileSection section)
        {
            writer.WriteHeader(section);
            foreach (var f in section.Schema.Fields)
                writer.WriteProperty(f);

            writer.WriteFooter(section);
        }

        static void WriteHeader(this TextWriter writer, FileSection section) =>
            writer.WriteLine($"{new string('#', section.Level)} <<< {section.Name}");

        static void WriteColumns(this TextWriter writer, FileSection section) =>
            writer.WriteLine(string.Join(", ", from f in section.Schema.Fields select f.Name));

        static void WriteRow(this TextWriter writer, FileSection section, object row) =>
            writer.WriteLine(string.Join(" ", from f in section.Schema.Fields select f.Format(row)));
        
        static void WriteFooter(this TextWriter writer, FileSection section) =>
            writer.WriteLine($"{new string('#', section.Level)} >>>");

        static void WriteProperty(this TextWriter writer, FileField field) =>
            writer.WriteLine($"{field.Name}: {field.Format()}");
    }
}
