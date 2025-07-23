using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class MainSettings
{
    public float[] Grid { get; set; }
    public SnapSettings Snap { get; set; }
    public MirrorSettings Mirror { get; set; }
    public bool ShowCorners { get; set; }
    public bool ShowOutline { get; set; }

    public MainSettings()
    {
    }

    public MainSettings(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        Grid = data.ToSingleArray(2, ref pos);
        Snap = new SnapSettings(data[8..]);
        Mirror = new MirrorSettings(data[24..]);
        pos = 40;
        ShowCorners = data.ToBoolean(ref pos);
        pos = 14;
        ShowOutline = data.ToBoolean(ref pos);
    }
}