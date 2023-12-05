using System.Text;
using Day03;

string? line = null;

var parts = new List<Part>();   
var symbols = new List<Symbol>();

// Parse
var y = 0;
while ((line = Console.In.ReadLine()) != null) 
{
    var result = LineParser.Parse(y, line);

    parts.AddRange(result.Parts);
    symbols.AddRange(result.Symbols);

    y++;
}

// Process
var accumulator = 0;
foreach (var part in parts) 
{
    if (symbols.Any(s => part.Position.IsAdjacentTo(s.Position)))
    {
        Console.WriteLine($"{part.PartNumber} ({part.Position.TopLeft.X}, {part.Position.TopLeft.Y})x({part.Position.BottomRight.X}, {part.Position.BottomRight.Y})");
        accumulator += part.PartNumber;
    }
}

var gearAccumulator = 0;
foreach (var symbol in symbols)
{
    if (symbol.Character != '*') continue;
    var gearValues = parts.Where(p => symbol.Position.IsAdjacentTo(p.Position)).ToArray();
    if (gearValues.Length != 2) continue;

    gearAccumulator += gearValues[0].PartNumber * gearValues[1].PartNumber;
}

Console.WriteLine(accumulator);
Console.WriteLine(gearAccumulator);