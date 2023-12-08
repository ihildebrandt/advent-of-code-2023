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

    public static void CalculateAllWinners(char[] directions)
    {
        foreach (var kvp in Nodes)
        {
            kvp.Value.CalculateWinners(directions);
        }
    }

    public static void CalculateAllLoopCounts()
    {
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

    private Node? _lastNodeInChain;

    public string Id => _id;
    public Node Left => Nodes[_left];
    public Node Right => Nodes[_right];

    public bool IsWinner => _id.EndsWith("Z");
    public IList<long> WinnersInChain => _winners;
    public Node LastNodeInChain => _lastNodeInChain!;

    private Node(string id, string left, string right)
    {
        _id = id;
        _left = left;
        _right = right;
    }

    public void CalculateWinners(char[] directions)
    {
        var node = this;

        if (node.IsWinner) _winners.Add(0);
        for (var i = 0; i < directions.Length; i++)
        {
            var direction = directions[i];
            node = direction == 'R' ? node.Right : node.Left;
            if (node.IsWinner) _winners.Add(i + 1);
        }

        _lastNodeInChain = node;
    }
}