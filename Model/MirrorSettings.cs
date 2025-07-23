using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class MirrorSettings
{
    public bool LeftRight { get; set; }
    public bool UpDown { get; set; }
    public bool Rotational { get; set; }
    public bool Active { get; set; }
    public int RotationDivisions { get; set; }
    public float[] Center { get; set; }

    public MirrorSettings() { }

    public MirrorSettings(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        LeftRight = data.ToBoolean(ref pos);
        UpDown = data.ToBoolean(ref pos);
        Rotational = data.ToBoolean(ref pos);
        Active = data.ToBoolean(ref pos);
        RotationDivisions = data.ToInt32(ref pos);
        Center = data.ToSingleArray(2, ref pos);
    }
}