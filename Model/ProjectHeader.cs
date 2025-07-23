using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class ProjectHeader
{
    public int DocumentVersion { get; set; }
    public int ApplicationVersion { get; set; }

    public ProjectHeader()
    {
    }


    public ProjectHeader(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        DocumentVersion = data.ToInt32(ref pos);
        ApplicationVersion = data.ToInt32(ref pos);
    }
}