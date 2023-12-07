using System.Text;

namespace Day07;

public class Hand 
{
    private static readonly char[] CardRanks = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' }; 

    public static Hand Parse(string line)
    {
        var parts = line.Split(' ');

        var cards = parts[0].ToCharArray().Select(c => {
            var i = Array.IndexOf(CardRanks, c);
            if (i == -1) throw new Exception();
            return (long)i;
        });

        var bid = long.Parse(parts[1]);

        return new Hand(bid, cards.ToArray());
    }

    private static long DetermineRank(long[] _cards)
    {
        var cards = new long[_cards.Length];
        Array.Copy(_cards, cards, cards.Length);
        Array.Sort(cards);

        bool fiveOfAKind = false;
        bool fourOfAKind = false;
        bool threeOfAKind = false;
        bool twoPair = false;
        bool onePair = false;

        var c = 0;

        int i, j;
        for (i = 0; i < cards.Length; i++)
        {
            var a = cards[i];
            for (j = i + 1; j < cards.Length; j++)
            {
                var b = cards[j];
                c++;

                if (a != b)
                {
                    i = j - 1;
                    switch (c) 
                    {
                        case 5:
                            fiveOfAKind = true;
                            break;
                        case 4:
                            fourOfAKind = true;
                            break;
                        case 3:
                            threeOfAKind = true;
                            break;
                        case 2:
                            twoPair = onePair;
                            onePair = true;
                            break;
                    }

                    c = 0;
                    break;
                }
            }

            i = j - 1;
        }

        if (c > 0) {
            switch (c) {
                case 4:
                    fiveOfAKind = true;
                    break;
                case 3:
                    fourOfAKind = true;
                    break;
                case 2:
                    threeOfAKind = true;
                    break;
                case 1:
                    twoPair = onePair;
                    onePair = true;
                    break;
            }
        }

        if (fiveOfAKind) return 6;
        if (fourOfAKind) return 5;
        if (threeOfAKind && onePair) return 4;
        if (threeOfAKind) return 3;
        if (twoPair) return 2;
        if (onePair) return 1;
        return 0;
    }

    private readonly long _bid;

    private readonly long[] _cards;

    private readonly long _handRank;

    public long[] Cards => _cards;
    public long Rank => _handRank;
    public long Bid => _bid;

    public Hand(long bid, long[] cards)
    {
        _bid = bid;
        _cards = cards;
        
        _handRank = DetermineRank(cards);
    }

    public override string ToString()
    {
        return $"{string.Join("", _cards.Select(c => CardRanks[c]))} {_bid} {_handRank}";
    }
}