using System.Text;

namespace Day05;

public class Map
{
    public static Map Parse(IEnumerator<string> lineFeed)
    {
        var mapParts = lineFeed.Current
            .Split(' ')[0]
            .Split('-');

        var source = (ResourceType)Enum.Parse(typeof(ResourceType), mapParts[0]);
        var destination = (ResourceType)Enum.Parse(typeof(ResourceType), mapParts[2]);

        // Console.WriteLine($"Found Map from {source} to {destination}");
        var map = new Map(source, destination);

        while (lineFeed.MoveNext() && (lineFeed.Current != string.Empty))
        {
            // Console.WriteLine($"Found Range {lineFeed.Current}");
            var rangeParts = lineFeed.Current.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            map.AddRange(long.Parse(rangeParts[1]), long.Parse(rangeParts[0]), long.Parse(rangeParts[2]));
        }

        return map;
    }

    private readonly ResourceType _sourceType;
    private readonly ResourceType _destinationType;

    public ResourceType Source => _sourceType;
    public ResourceType Destination => _destinationType;
    public IList<Range> Ranges => _ranges; 

    public long MaxRangeDestination => _ranges.Max(r => r.DestinationEnd);

    private readonly IList<Range> _ranges = new List<Range>();

    public Map(ResourceType source, ResourceType destination)
    {
        _sourceType = source;
        _destinationType = destination;
    }

    public void AddRange(long source, long destination, long length)
    {
        var range = new Range(source, destination, length);
        AddRange(range);
    }

    public void AddRange(Range range)
    {
        _ranges.Add(range);
    }

    public long FindRangeMappedValue(long input)
    {
        foreach (var range in _ranges) 
        {
            // Console.WriteLine($"Checking source range from {range.SourceOrigin} to {range.SourceOrigin + range.Length - 1}");
            if (input >= range.SourceOrigin && input < range.SourceOrigin + range.Length)
            {
                long dist = input - range.SourceOrigin;
                // Console.WriteLine($"Returning {range.DestinationOrigin} + {dist}");
                return range.DestinationOrigin + dist;
            }
        }

        return input;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Source} -> {Destination}:");
        foreach (var line in _ranges) {
            sb.AppendLine($"    {line}");
        }
        return sb.ToString();
    }
}