using Cds.IO.Schema;
using System;
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
        public static void Read(this FileSchema schema, TextReader reader) 
        {
            using (reader)
            {
                foreach (var field in schema.Fields)
                    while (!reader.TryReadProperty(field)) ;

                foreach (var section in schema.Sections)
                    while (!reader.TryReadSection(section)) ;
            }
        }

        static bool TryReadSection(this TextReader reader, FileSection section)
        {
            while (!reader.TryReadHeader(section)) ;

            if (section.IsList)            
            {
                while (!reader.TryReadColumns(section)) ;
                while (!reader.TryReadRows(section)) ;
                return true;
            }

            foreach (var f in section.Schema.Fields)
                while (!reader.TryReadProperty(f)) ;
            
            foreach (var s in section.Schema.Sections)
                while (!reader.TryReadSection(s)) ;
            
            return true;
        }

        static bool TryReadHeader(this TextReader reader, FileSection section)
        {
            var line = reader.ReadLine()?.Trim()
                ?? throw new EndOfStreamException();

            return line.StartsWith(new string('#', section.Level) + " <<<") &&
                line.ToUpper().Contains(section.Name.ToUpper());
        }

        static bool TryReadProperty(this TextReader reader, FileField field)
        {
            var line = reader.ReadLine()?.Trim()
                ?? throw new EndOfStreamException();

            if (!line.Contains(':'))
                return false;

            var split = line.IndexOf(':');
            if (split == -1)
                return false;

            var name = line.Substring(0, split).Trim();
            var value = line.Substring(split + 1).Trim();
            field.Value = Convert.ChangeType(value, field.Type);
            return true;
        }

        static bool TryReadColumns(this TextReader reader, FileSection section)
        {
            var line = reader.ReadLine()?.Trim()
                ?? throw new EndOfStreamException();

            return section.Schema.Fields.All(
                f => line.Contains(f.Name));
        }


        static bool TryReadRows(this TextReader reader, FileSection section)
        {
            var line = reader.ReadLine()?.Trim()
                ?? throw new EndOfStreamException();

            if (string.IsNullOrWhiteSpace(line))
                return false;

            if (line.StartsWith(new string('#', section.Level) + " >>>"))
                return true;

            var values = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var row = section.CreateObject();
            for (int i = 0; i < section.Schema.Fields.Count; i++)
                section.Schema.Fields[i][row] = Convert.ChangeType(values[i], section.Schema.Fields[i].Type);

            section.List.Add(row);
            return false;
        }
    }
}
