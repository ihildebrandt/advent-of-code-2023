using Day06;

var times = Console.In.ReadLine()!
    .Split(':')[1]
    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
    .Select(t => long.Parse(t))
    .ToArray();

var dists = Console.In.ReadLine()!
    .Split(':')[1]
    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
    .Select(d => long.Parse(d))
    .ToArray();

var analyzers = new List<RaceAnalyzer>();
for (var i = 0; i < times.Length; i++) 
{
    analyzers.Add(new RaceAnalyzer(times[i], dists[i]));
}

long accumulator = 1;
foreach (var analyzer in analyzers)
{
    var winCount = analyzer.GetWinCount();
    accumulator = accumulator * winCount;
}

Console.WriteLine(accumulator);