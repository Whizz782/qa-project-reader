using System.Text;

namespace QaProjectReader.Model;

internal class QaProject
{
    public ProjectHeader Header { get; set; }
    public MainSettings MainSettings { get; set; }
    public Palette Palette { get; set; }
    public ImageSettings ImageSettings { get; set; }
    public VertexList VertexList { get; set; }
    public EdgeList EdgeList { get; set; }
    public ShapeList ShapeList { get; set; }

    public QaProject(IEnumerable<ProjectSection> sections)
    {
        foreach (var section in sections)
        {
            switch (section.Type)
            {
                case "QAFH":
                    Header = new ProjectHeader(section.Data);
                    break;
                case "GSET":
                    MainSettings = new MainSettings(section.Data);
                    break;
                case "PALE":
                    Palette = new Palette(section.Data);
                    break;
                case "BLCK":
                    ImageSettings = new ImageSettings(section.Data);
                    break;
                case "VTXL":
                    VertexList = new VertexList(section.Data);
                    break;
                case "EDGL":
                    EdgeList = new EdgeList(section.Data);
                    break;
                case "SHPL":
                    ShapeList = new ShapeList(section.Data);
                    break;
                case "SHP1":
                    ShapeList.Add(new Shape(section.Data));
                    break;
                default:
                    Console.WriteLine(section.ToString());
                    break;
            }
        }
    }
}