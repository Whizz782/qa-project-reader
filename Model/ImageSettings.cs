using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class ImageSettings
{
    public string? Name { get; set; }
    public int[] SizeInPixels { get; set; }
    public float[] Dpi { get; set; }
    public float[] SizeInMillimeters { get; set; }
    public float[] ImageOffset { get; set; }

    public ImageSettings()
    {
    }

    public ImageSettings(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        Name = data.GetString(ref pos);
        var h = data.ToInt32(ref pos);
        var w = data.ToInt32(ref pos);
        SizeInPixels = [w, h];
        Dpi = data.ToSingleArray(2, ref pos);
        if (Dpi[1] == 0)
            Dpi[1] = Dpi[0];
        SizeInMillimeters = data.ToSingleArray(2, ref pos);
        ImageOffset = data.ToSingleArray(2, ref pos);
    }
}