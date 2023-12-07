using System.Text;

namespace Day07;

public class Hand 
{
    private static readonly char[] CardRanks = new char[] { 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' }; 

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

        int wildcards = 0;

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
            if (a == 0)
            {
                wildcards++;
            }
            else 
            {
                for (j = i + 1; j < cards.Length; j++)
                {
                    var b = cards[j];
                    if (b == 0)
                    {
                        wildcards++;
                    }
                    else
                    {
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
                }
                i = j - 1;
            }
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

        if (fiveOfAKind) 
        {
            return 6;
        }

        if (fourOfAKind)
        {
            if (wildcards == 1)
            { 
                return 6;
            }
            else 
            {
                return 5;
            }
        }

        if (threeOfAKind && onePair) 
        {
            return 4;
        }

        if (threeOfAKind) 
        {
            if (wildcards == 2)
            {
                return 6;
            }
            else if (wildcards == 1)
            {
                return 5;
            }
            else 
            {
                return 3;
            }
        }

        if (twoPair)  {
            if (wildcards == 1)
            {
                return 4;
            }
            else
            {
                return 2;
            }
        }

        if (onePair) 
        {
            if (wildcards == 3)
            {
                return 6;
            }
            else if (wildcards == 2)
            {
                return 5;
            }
            else if (wildcards == 1)
            {
                return 3;
            }
            else 
            {
                return 1;
            }
        }

        if (wildcards == 5) {
            return 6;
        } else if (wildcards == 4) {
            return 6;
        } else if (wildcards == 3) {
            return 5;
        } else if (wildcards == 2) {
            return 3;
        } else if (wildcards == 1) {
            return 1;
        } else {
            return 0;
        }
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