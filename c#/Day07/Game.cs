using System.Text;

namespace Day07;

public class Game
{
    public static Game Parse(TextReader lines)
    {
        string? line = null;

        var game = new Game();
        while ((line = lines.ReadLine()) != null)
        {
            if (line.Trim() == "<EOF>") break;
            var hand = Hand.Parse(line);
            game._hands.Add(hand);
        }   
        return game;
    }

    public IList<Hand> Hands => _hands;

    private readonly IList<Hand> _hands;

    private Game()
    {
        _hands = new List<Hand>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var hand in _hands)
        {
            sb.AppendLine(hand.ToString());
        }
        return sb.ToString();
    }
}