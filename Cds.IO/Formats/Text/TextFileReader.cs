using Cds.IO.Converters;
using Cds.IO.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Formats.Text
{
    static class TextFileReader
    {
        public static void Read<T>(this CdsFile<T> file, TextReader reader)
            where T : CdsFile<T>, new()
        {
            var schema = CdsFile<T>.Schema;
            using (var scanner = new TextScanner(reader))
            {
                scanner.ReadProperties(schema.Fields, file);
                scanner.ReadSections(schema.Sections, file);
            }
        }

        static void ReadProperties(this TextScanner scanner, IReadOnlyList<FileField> fields, object target)
        {
            void ReadField(int index)
            {
                scanner.SkipWhiteSpace();
                if (!scanner.Content)
                    return;

                if (fields.Take(index).Any(f => scanner.TryGetProperty(f, out var value)))
                    return;

                for (int i = index; i < fields.Count; i++)
                {
                    var field = fields[i];
                    if (scanner.TryGetProperty(field, out var value))
                    {
                        field[target] = FieldConverter.Convert(field.Type, value);

                        if(scanner.Read())
                            ReadField(i + 1);
                                                    
                        return;
                    }
                }

                if(scanner.Read())
                    if(!fields.Take(index).Any(f => scanner.TryGetProperty(f, out var value)))
                        ReadField(index);
            }

            ReadField(0);
        }

        static void ReadSections(this TextScanner scanner, IReadOnlyList<FileSection> sections, object target)
        {
            foreach (var section in sections)
            {
                while (!scanner.TryGetSectionStart(section))
                    if (!scanner.Read())
                        return;

                if (!scanner.Read())
                    return;

                if (section.IsText)
                {
                    if (scanner.TryGetText(out var text))
                        section[target] = text;
                }
                else if (section.IsTable)
                    section[target] = scanner.ReadTable(section);
                else if(section.IsGroup)
                    section[target] = scanner.ReadGroup(section);
                else
                {
                    section[target] = section.CreateObject();
                    scanner.ReadProperties(section.Schema.Fields, section[target]);
                    scanner.ReadSections(section.Schema.Sections, section[target]);
                }
                                
                if (!scanner.TrySkipSectionEnd(section))
                    return;
            }
        }

        static IList ReadTable(this TextScanner scanner, FileSection section)
        {
            var list = section.CreateList();

            scanner.SkipWhiteSpace();
            if (!scanner.TryGetColumns(section))
                return list;

            while (scanner.Read())
            {
                scanner.SkipWhiteSpace();
                if (!scanner.TryGetRows(section, out var values))
                    return list;
                
                var row = section.CreateObject();
                foreach (var x in section.Schema.Fields.Zip(values, (f, v) => new { Field = f, Value = v }))
                    x.Field[row] = FieldConverter.Convert(x.Field.Type, x.Value);

                list.Add(row);
            }

            return list;
        }

        static IList ReadGroup(this TextScanner scanner, FileSection section)
        {
            var list = section.CreateList();
            while(!scanner.TryGetSectionEnd(section))
            {
                var item = section.CreateObject();
                scanner.ReadProperties(section.Schema.Fields, item);
                scanner.ReadSections(section.Schema.Sections, item);
                list.Add(item);
            }

            return list;
        }
    }
}
