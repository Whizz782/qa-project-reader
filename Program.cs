using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using QaProjectReader.Model;

if (args.Length != 2)
{
    Console.WriteLine("Usage: QaProjectReader.exe input.qa2 output.json");
    return 1;
}
var sourceFile = args[0];
var destFile = args[1];
if (!File.Exists(sourceFile))
{
    Console.WriteLine("Source not found: " + sourceFile);
    return 1;
}

var content = ProjectSection.FromFile(sourceFile);
var project = new QaProject(content);

var opts = new JsonSerializerOptions
    { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};
var json = JsonSerializer.Serialize(project, opts);
File.WriteAllText(destFile, json, Encoding.UTF8);

Console.WriteLine("Done.");
return 0;