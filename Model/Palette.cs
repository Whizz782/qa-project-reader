using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class Palette
{
    private long[] _colors;

    public string[] Colors
    {
        get
        {
            return _colors.Select(c => "#" + c.ToString("x6")).ToArray();
        }
    }

    public Palette()
    {
    }

    public Palette(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        var count = data.ToInt32(ref pos);
        _colors = new long[count];
        for (var i = 0; i < count; i++)
        {
            _colors[i] = data.ToInt64(ref pos);
        }
    }
}