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
            using (reader)
            {
                foreach (var field in schema.Fields)
                    if (!reader.TryReadProperty(field, file))
                        throw new FormatException();

                foreach (var section in schema.Sections)
                    if(!reader.TryReadSection(section, file))
                        throw new FormatException();
            }
        }
        
        static bool TryReadSection(this TextReader reader, FileSection section, object target)
        {
            if (!reader.TryReadHeader(section))
                return false;

            if (section.IsTable)
                return reader.TryReadTable(section, target);

            if(section.IsGroup)
                return reader.TryReadGroup(section, target);

            if (section[target] == null)
                section[target] = section.CreateObject();

            foreach (var f in section.Schema.Fields)
                if (!reader.TryReadProperty(f, section[target]))
                    return false;

            foreach (var s in section.Schema.Sections)
                if (!reader.TryReadSection(s, section[target]))
                    return false;

            if (!reader.TryReadFooter(section))
                return false;

            return true;
        }

        static bool TryReadTable(this TextReader reader, FileSection section, object target)
        {
            if (section[target] == null)
                section[target] = section.CreateList();

            if (!reader.TryReadColumns(section))
                return false;

            while (reader.TryReadRows(section, (IList)section[target])) ;
            return true;
        }

        static bool TryReadGroup(this TextReader reader, FileSection section, object target)
        {
            if (section[target] == null)
                section[target] = section.CreateList();
            
            while (reader.TryReadItem(section, (IList)section[target])) ;
            return true;
        }

        static bool TryReadItem(this TextReader reader, FileSection section, IList list)
        {
            var target = section.CreateObject();

            foreach (var f in section.Schema.Fields)
                if (!reader.TryReadProperty(f, target))
                    return false;

            foreach (var s in section.Schema.Sections)
                if (!reader.TryReadSection(s, target))
                    return false;

            list.Add(target);
            return true;
        }


        static bool TryReadHeader(this TextReader reader, FileSection section)
        {
            while (true)
            {
                var line = reader.ReadLine()?.Trim();
                if (line == null)
                    return false;

                if (line.StartsWith(">>>"))
                    return false;

                if(line.StartsWith(new string('<', section.Level)) &&
                    line.ToUpper().Contains(section.Name.ToUpper()))
                    return true;
            }
        }

        static bool TryReadFooter(this TextReader reader, FileSection section)
        {
            while (true)
            {
                var line = reader.ReadLine()?.Trim();
                if (line == null)
                    return false;

                if (line.StartsWith(new string('>', section.Level)))
                    return true;
            }
        }

        static bool TryReadProperty(this TextReader reader, FileField field, object target)
        {
            while (true)
            {
                var line = reader.ReadLine()?.Trim();
                if (line == null)
                    return false;

                if (line.StartsWith(">>>"))
                    return false;

                var split = line.IndexOf(':');
                if (split == -1)
                    continue;

                var name = line.Substring(0, split).Trim();
                if (field.Name != name)
                    continue;

                var value = line.Substring(split + 1).Trim();
                field[target] = Convert.ChangeType(value, field.Type);
                return true;
            }
        }

        static bool TryReadColumns(this TextReader reader, FileSection section)
        {
            while (true)
            {
                var line = reader.ReadLine()?.Trim();
                if (line == null)
                    return false;

                if (line.StartsWith(">>>"))
                    return false;

                if (Enumerable.SequenceEqual(
                    from f in section.Schema.Fields
                    select f.Name.Trim(),
                    from c in line.Split(',')
                    select c.Trim()))
                    return true;
            }
        }
        
        static bool TryReadRows(this TextReader reader, FileSection section, IList list)
        {
            while (true)
            {
                var line = reader.ReadLine()?.Trim();
                if (line == null)
                    return false;

                if (line.StartsWith(">>>"))
                    return false;

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var row = section.CreateObject();
                for (int i = 0; i < section.Schema.Fields.Count; i++)
                    section.Schema.Fields[i][row] = Convert.ChangeType(values[i], section.Schema.Fields[i].Type);

                list.Add(row);
                return true;
            }
        }
    }
}
