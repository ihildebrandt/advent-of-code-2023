using System.Diagnostics;
using AdventOfCode;
using Day08;

string? line = null;
Node? root = null;

var directions = Console.In.ReadLine()!.ToCharArray();
Console.In.ReadLine();

while ((line = Console.In.ReadLine()) != null)
{
    if (line.Trim() == "<EOF>") break;
    var n = Node.Parse(line);
    if (root == null) root = n;
}

var nodes = Node.GetStartNodes();
var winLengths = nodes.Select(n => n.GetWinDistance(directions)).ToArray();
var primeFactors = winLengths.Select(l => MathUtil.GetPrimeFactors(l)).ToArray();

var lcm = MathUtil.GetLeastCommonMultiple(primeFactors);
Console.WriteLine(lcm);
