namespace Day04;

public class Card 
{
    public static Card Parse(string line) 
    {
        var parts = line.Split(':', 2);
        var cardId = int.Parse(parts[0].Split(' ', 2)[1].Trim());
        var numberParts = parts[1].Split('|', 2);
        
        var winningNumbers = numberParts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToArray();
        var cardNumbers = numberParts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToArray();

        return new Card(cardId, winningNumbers, cardNumbers);
    }

    private readonly int _id;
    private readonly int[] _winningNumbers;
    private readonly int[] _cardNumbers;

    private int _count = 1;

    public int Id => _id;
    public int Count => _count;

    private Card(int id, int[] winningNumbers, int[] cardNumbers)
    {
        _id = id;
        _winningNumbers = winningNumbers;
        _cardNumbers = cardNumbers;
    }

    public void Increment(int amount)
    {
        _count += amount;
    }

    public int GetMatchCount()
    {
        return _cardNumbers.Count(c => _winningNumbers.Any(n => c == n));
    }

    public int GetScore()
    {
        var accumulator = 0;

        for (var i = 0; i < _winningNumbers.Length; i++) 
        {
            if (_cardNumbers.Any(n => n == _winningNumbers[i]))
            {
                accumulator += accumulator == 0 ? 1 : accumulator;
            }
        }

        return accumulator;
    }
}