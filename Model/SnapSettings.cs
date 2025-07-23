using QaProjectReader.Helpers;

namespace QaProjectReader.Model;

internal class SnapSettings
{
    public bool ToGrid { get; set; }
    public bool ToVertex { get; set; }
    public bool ToAngle { get; set; }
    public float VertexDistance { get; set; }
    public float BaseAngle { get; set; }
    public float StepAngle { get; set; }

    public SnapSettings()
    {
    }

    public SnapSettings(ReadOnlySpan<byte> data)
    {
        var pos = 0;
        ToGrid = data.ToBoolean(ref pos);
        ToVertex = data.ToBoolean(ref pos);
        VertexDistance = data.ToSingle(ref pos);
        pos++;
        BaseAngle = data.ToSingle(ref pos); 
        StepAngle = data.ToSingle(ref pos);
        pos++;
        ToAngle = data.ToBoolean(ref pos);
    }
}