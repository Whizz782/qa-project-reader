using QaProjectReader.Helpers;
using System.Diagnostics;

namespace QaProjectReader.Model;

internal class ProjectSection
{
    public string Type { get; }
    public byte[] Data { get; }

    protected ProjectSection(string type, byte[] content, int offset, int length)
    {
        Type = type;
        Data = new byte[length];
        Array.Copy(content, offset, Data, 0, length);
    }

    public static IEnumerable<ProjectSection> FromFile(string sourceFile)
    {
        var content = File.ReadAllBytes(sourceFile);
        var pos = 0;
        while (pos < content.Length - 8)
        {
            ReadOnlySpan<byte> span = content.AsSpan(pos, 8);
            var p = 0;
            var header = span.ToAscii(4, ref p);
            var sectionLength = span.ToInt32(ref p);
            if (sectionLength <= content.Length - p)
            {
                yield return new ProjectSection(header, content, pos + p, sectionLength - p);
            }

            pos += sectionLength;
        }
        Debug.Assert(pos == content.Length);
    }

    public override string ToString()
    {
        return Type + " (" + Data.Length + ")";
    }
}