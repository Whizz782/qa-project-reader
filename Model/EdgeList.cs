using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class EdgeList
{
    public Edge[] Edges { get; set; } = [];

    public EdgeList()
    {
    }

    public EdgeList(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        var count =data.ToInt32(ref pos);
        Edges = new Edge[count];
        for (var i = 0; i < count; i++)
        {
            Edges[i] = new Edge(data, ref pos);
        }
    }
}

internal class Edge
{
    public int Index { get; set; }
    public int StartVertex { get; set; }
    public int EndVertex { get; set; }
    public float[]? StartControlPoint { get; set; }

    public float[]? EndControlPoint { get; set; }

    public Edge()
    {
    }

    public Edge(ReadOnlySpan<byte> data, ref int pos)
    {
        var len = data[pos++];
        switch (len)
        {
            case 7:
                Index = data.ToInt16(ref pos);
                StartVertex = data.ToInt16(ref pos);
                EndVertex = data.ToInt16(ref pos);
                break;
            case 29:
                Index = data.ToInt32(ref pos);
                StartVertex = data.ToInt32(ref pos);
                EndVertex = data.ToInt32(ref pos);
                StartControlPoint = data.ToSingleArray(2, ref pos);
                EndControlPoint = data.ToSingleArray(2, ref pos);
                break;
        }
    }
}