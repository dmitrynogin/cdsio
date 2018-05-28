using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Formats.Text
{
    static class RowParser
    {
        public static string[] ParseRow(this string line)
        {
            using (var reader = new StringReader(line))
                return reader.ReadRow().ToArray();
        }

        static IEnumerable<string> ReadRow(this TextReader reader)
        {
            while (reader.TryReadValue(out var value))
                yield return value;
        }

        static bool TryReadValue(this TextReader reader, out string value)
        {
            reader.SkipWhiteSpaces();
            return reader.Quote()
                ? reader.TryReadQuotedValue(out value)
                : reader.TryReadUnquotedValue(out value);
        }

        static bool TryReadQuotedValue(this TextReader reader, out string value)
        {
            value = null;
            if (reader.Read() != '"')
                return false;

            var sb = new StringBuilder();
            while(true)
                switch (reader.Read())
                {
                    case -1:
                        return false;

                    case int c when c == '"':
                        if (reader.Quote())
                        {
                            sb.Append((char)reader.Read());
                            break;
                        }
                        else
                        {
                            value = sb.ToString();
                            return true;
                        }

                    case int c:
                        sb.Append((char)c);
                        break;
                }
        }

        static bool TryReadUnquotedValue(this TextReader reader, out string value)
        {
            value = null;
            if (!reader.Content())
                return false;

            var sb = new StringBuilder();
            while (reader.Content())
                sb.Append((char)reader.Read());

            value = sb.ToString();
            if (value == "N/A")
                value = null;

            return true;
        }

        static void SkipWhiteSpaces(this TextReader reader)
        {
            while (reader.WhiteSpace())
                reader.Read();
        }

        static bool Content(this TextReader reader) =>
            !reader.EndOfFile() && !reader.WhiteSpace(); 

        static bool EndOfFile(this TextReader reader) =>
            reader.Peek() == -1;

        static bool Quote(this TextReader reader) =>
            (char)reader.Peek() == '"';

        static bool WhiteSpace(this TextReader reader) =>
            char.IsWhiteSpace((char)reader.Peek());
    }
}
