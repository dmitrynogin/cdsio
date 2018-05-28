namespace Cds.IO.Formats.Text
{
    static class TextFingerprint
    {
        public static string Unify(this string text) => text
            .Replace(" ", "")
            .Replace("\t", "")
            .Trim()
            .ToLower();
    }
}
