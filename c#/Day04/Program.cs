
using Day04;

var cards = new List<Card>();
string? line = null; 

while ((line = Console.In.ReadLine()) != null)
{
    Console.WriteLine(line);
    cards.Add(Card.Parse(line));
}

var accumulator = 0;
foreach (var card in cards) 
{
    accumulator += card.GetScore();
}

var accumulator2 = 0;
for (var i = 0; i < cards.Count(); i++)
{
    var card = cards[i];
    accumulator2 += card.Count;

    // Console.WriteLine($"{card.Id}: {card.GetMatchCount()}");
 
    for (var j = i + 1; j < int.Min(i + card.GetMatchCount() + 1, cards.Count()); j++)
    {
        // Console.WriteLine($"Adding {card.Count} to {cards[j].Id}");
        cards[j].Increment(card.Count);
    }
}

Console.WriteLine(accumulator);
Console.WriteLine(accumulator2);