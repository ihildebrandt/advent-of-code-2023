
using Day07;

var game = Game.Parse(Console.In);
var orderedHands = game.Hands
    .OrderByDescending(h => h.Rank)
    .ThenByDescending(h => h.Cards[0])
    .ThenByDescending(h => h.Cards[1])
    .ThenByDescending(h => h.Cards[2])
    .ThenByDescending(h => h.Cards[3])
    .ThenByDescending(h => h.Cards[4]);


Console.WriteLine(game);

var handPosition = orderedHands.Count();
var accumulator = 0L;
foreach (var hand in orderedHands) 
{
    Console.Write(hand);
    Console.WriteLine($": {handPosition} * {hand.Bid} = {handPosition * hand.Bid}");
    accumulator += handPosition * hand.Bid;
    handPosition--;
} 

Console.WriteLine(accumulator);