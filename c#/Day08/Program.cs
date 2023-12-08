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

Node.CalculateAllWinners(directions);

var node = Node.GetNode("AAA");
var accumulator = 0L;
while (!node.WinnersInChain.Any())
{
    accumulator += directions.Length;
    node = node.LastNodeInChain;
}
accumulator += node.WinnersInChain.First();
Console.WriteLine(accumulator);


var nodes = Node.GetStartNodes();

// I found each count and used a calculator 
// to get the LCM. I haven't implemented
// the LCM algorithm here yet, though :/
// node 0 : 13201
// node 1 : 22411
// node 2 : 18727
// node 3 : 18113
// node 4 : 16271
// node 5 : 20569

