using Cds.IO.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace Cds.IO.Formats.Text
{
    class TextScanner : IDisposable
    {
        public TextScanner(TextReader reader)
        {
            Reader = reader ?? throw new ArgumentNullException(nameof(reader));
            Read();            
        }

        TextReader Reader { get; }
        string Line { get; set; }

        public void Dispose() =>
            Reader.Dispose();

        public bool Read()
        {
            Line = Reader.ReadLine();
            return !EndOfFile;
        }

        public bool EndOfFile => Line == null;

        public bool Content =>
            !EndOfFile &&
            !WhiteSpace &&
            !StartOfSection &&
            !EndOfSection;

        public bool WhiteSpace => 
            !EndOfFile && 
            IsNullOrWhiteSpace(Line);

        public bool StartOfSection =>
            !EndOfFile &&
            Line.StartsWith("<<<");

        public bool EndOfSection =>
            !EndOfFile &&
            Line.StartsWith(">>>");

        public void SkipWhiteSpace()
        {
            while (WhiteSpace)
                Read();
        }

        public bool TryGetSectionStart(FileSection section) =>
            StartOfSection &&
            Line.StartsWith(new string('<', section.Level)) &&
            Line.Unify().Contains(section.Name.Unify());

        public bool TryGetSectionEnd(FileSection section) =>
            EndOfSection && 
            Line.TrimEnd() == new string('>', section.Level);

        public bool TrySkipSectionEnd(FileSection section)
        {
            while (!TryGetSectionEnd(section))
                if (!Read())
                    return false;

            Read();
            return true;
        }

        public bool TryGetProperty(FileField field, out string value)
        {
            value = null;
            if (!Content)
                return false;

            var split = Line.IndexOf(':');
            if (split == -1)
                return false;

            var name = Line.Substring(0, split);
            if (name.Unify() != field.Name.Unify())
                return false;

            value = Line.Substring(split + 1).Trim();
            return true;
        }

        public bool TryGetColumns(FileSection section)
        {
            if (!Content)
                return false;

            return Enumerable.SequenceEqual(
                from f in section.Schema.Fields
                select f.Name.Unify(),
                from c in Line.Split(',')
                select c.Unify());
        }

        public bool TryGetRows(FileSection section, out string[] values)
        {
            values = new string[0];
            if (!Content)
                return false;

            values = Line.ParseRow();
            return section.Schema.Fields.Count <= values.Length;
        }

        public bool TryGetText(out string text)
        {
            text = null;
            if (EndOfFile || StartOfSection)
                return false;

            var sb = new StringBuilder();
            while (Content || WhiteSpace)
            {
                sb.AppendLine(Line);
                if (!Read())
                    return false;
            }

            text = sb.ToString().Trim();
            return true;
        }
    }
}
