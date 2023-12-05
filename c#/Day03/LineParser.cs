using System.Text;

namespace Day03;

public class LineParser
{
    private static StringBuilder _stringBuilder = new StringBuilder();

    public static (IEnumerable<Part> Parts, IEnumerable<Symbol> Symbols) Parse(int y, string line)
    {
        var parts = new List<Part>();
        var symbols = new List<Symbol>();

        var startX = -1;

        for (var x = 0; x < line.Length; x++) 
        {
            if (line[x] == '.') 
            {
                if (_stringBuilder.Length > 0) 
                {
                    var part = new Part(
                        int.Parse(_stringBuilder.ToString()), 
                        new Position(
                            new Coordinate(startX, y),
                            new Coordinate(x-1, y)
                        )
                    );
                    parts.Add(part);
                    _stringBuilder.Clear();
                    startX = -1;
                }
            }
            else if (line[x] >= '0' && line[x] <= '9')
            {
                startX = startX == -1 ? x : startX;
                _stringBuilder.Append(line[x]);
            }
            else 
            {
                if (_stringBuilder.Length > 0)
                {
                    var part = new Part(
                        int.Parse(_stringBuilder.ToString()), 
                        new Position(
                            new Coordinate(startX, y),
                            new Coordinate(x-1, y)
                        )
                    );
                    parts.Add(part);
                    _stringBuilder.Clear();
                    startX = -1;
                }

                var symbol = new Symbol(
                    line[x],
                    new Position(
                        new Coordinate(x, y),
                        new Coordinate(x, y)
                    )
                );
                symbols.Add(symbol);
            }
        }

        if (_stringBuilder.Length > 0) 
        {
            var part = new Part(
                int.Parse(_stringBuilder.ToString()), 
                new Position(
                    new Coordinate(startX, y),
                    new Coordinate(line.Length-1, y)
                )
            );
            parts.Add(part);
            _stringBuilder.Clear();
            startX = -1;
        }

        return (parts, symbols);
    }
}