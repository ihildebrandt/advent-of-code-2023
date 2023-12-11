using AdventOfCode;
using Day09;

var agg = Enumerator.EnumerateTextReader(Console.In)
    .Select(l => History.CalculateStep(l, false))
    .Aggregate((a, b) => a + b);

Console.WriteLine(agg);