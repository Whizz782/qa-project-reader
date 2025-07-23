using System.Diagnostics;
using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class VertexList
{
    public float[][] Vertices { get; set; }

    public VertexList()
    {
    }

    public VertexList(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        var count = data.ToInt32(ref pos);
        var size = data.ToInt32(ref pos);
        Debug.Assert(size == 8);
        Vertices = new float[count][];
        for (var i = 0; i < count; i++)
        {
            Vertices[i] = data.ToSingleArray(2, ref pos);
        }
    }
}