using System.Diagnostics;
using Day05;

var enumerable = Reader.ReadEnumerable(Console.In);
var enumerator = enumerable.GetEnumerator();
enumerator.MoveNext();

var seeds = enumerator.Current
    .Split(':')[1]
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(n => long.Parse(n))
    .ToArray();

enumerator.MoveNext();

var maps = new List<Map>();
while(enumerator.MoveNext())
{
    maps.Add(Map.Parse(enumerator));
}

foreach (var map in maps)
{
    Console.WriteLine(map);
}

var reduced = maps.Reduce();
Console.WriteLine(reduced);


/*
// The brute force approach worked, but it took forever to run
var locations = new List<long>();
for (var i = 0; i < seeds.Length; i += 2)
{
    for (var seed = seeds[i]; seed < seeds[i] + seeds[i+1]; seed++)
    {
        Map? map = null;
        long input = seed;
        long output = 0;
        var sourceResource = ResourceType.seed;

        do 
        {
            map = maps.Single(m => m.Source == sourceResource);
            output = map.FindRangeMappedValue(input);
            sourceResource = map.Destination;
            input = output;
        }
        while (map.Destination != ResourceType.location);

        locations.Add(output);
    }
}

Console.WriteLine(locations.Min());
*/