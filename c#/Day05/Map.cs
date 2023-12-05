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

    private readonly IList<(long SourceOrigin, long DestinationOrigin, long Length)> _ranges = new List<(long, long, long)>();

    private Map(ResourceType source, ResourceType destination)
    {
        _sourceType = source;
        _destinationType = destination;
    }

    public void AddRange(long source, long destination, long length)
    {
        _ranges.Add((source, destination, length));
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
}