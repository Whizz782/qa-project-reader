using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class ShapeList
{
    private int _readIndex;
    public Shape[] Shapes { get; set; }

    public ShapeList()
    {
    }

    public ShapeList(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        var count = data.ToInt32(ref pos);
        Shapes = new Shape[count];
    }

    public void Add(Shape shape)
    {
        Shapes[_readIndex++] = shape;
    }
}

internal class Shape
{
    public int Index { get; set; }
    public int ParentIndex { get; set; }
    public int[] Children { get; set; }
    public int[] Edges { get; set; }
    public bool[] NewSegment { get; set; }
    private readonly int _color;
    public string Color => "#" + (_color & 0xFFFFFF).ToString("x6");
    public string? Name { get; set; }
    public int SwatchId { get; set; }
    public short SelectedState { get; set; }

    public Shape()
    {
    }

    public Shape(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        Index = data.ToInt32(ref pos);
        Edges = data.ToInt32Array(ref pos)!;
        NewSegment = data.ToBooleanArray(ref pos)!;
        _color = data.ToInt32(ref pos);
        ParentIndex = data.ToInt32(ref pos);
        Children = data.ToInt32Array(ref pos)!;
        Name = data.GetString(ref pos);
        SwatchId = data.ToInt32(ref pos);
        SelectedState = data.ToInt16(ref pos);
    }
}