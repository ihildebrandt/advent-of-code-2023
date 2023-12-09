namespace Day08;

public class Node 
{
    private static readonly IDictionary<string, Node> Nodes = new Dictionary<string, Node>();

    public static Node Parse(string line)
    {
        var parts = line.Split("=");
        var id = parts[0].Trim();
        var lr = parts[1].Trim(' ','(',')').Split(',');

        var node = new Node(id, lr[0].Trim(), lr[1].Trim());
        Nodes[id] = node;
        return node;
    }

    public static Node GetNode(string id)
    {
        return Nodes[id];
    }

    public static IList<Node> GetStartNodes()
    {
        return Nodes
            .Where(kvp => kvp.Key.EndsWith("A"))
            .Select(kvp => kvp.Value)
            .ToList();
    }

    private readonly string _id;
    private readonly string _left;
    private readonly string _right;
    private readonly IList<long> _winners = new List<long>();

    public string Id => _id;
    public Node Left => Nodes[_left];
    public Node Right => Nodes[_right];

    public bool IsWinner => _id.EndsWith("Z");
    public IList<long> WinnersInChain => _winners;

    private Node(string id, string left, string right)
    {
        _id = id;
        _left = left;
        _right = right;
    }

    public long GetWinDistance(char[] directions)
    {
        var distance = 0;
        var node = this;

        while (!node.IsWinner) 
        {
            var direction = directions[distance % directions.Length];
            node = direction == 'R' ? node.Right : node.Left;
            distance++;
        }

        return distance;
    }
}