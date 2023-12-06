namespace Day06;

public class RaceAnalyzer
{
    private readonly long _time;
    private readonly long _distance;
    
    public RaceAnalyzer(long time, long distance)
    {
        _time = time;
        _distance = distance;
    }

    /*
    public int GetWinCount()
    {
        var holdTime = _time / 2 + _time % 2;
        var halfHoldTime = holdTime;
        while (GetTravelDistance(holdTime) > _distance) {
            holdTime--;
        }
        var  minHoldTime = holdTime + 1;
        var maxHoldTime = halfHoldTime + (halfHoldTime - minHoldTime) - _time % 2;

        Console.WriteLine($"{maxHoldTime} - {minHoldTime} + 1 = {maxHoldTime - minHoldTime + 1}");
        // Console.WriteLine();

        return maxHoldTime - minHoldTime + 1;
    }
    */

    public long GetWinCount()
    {
        var winMax = long.MinValue;
        var winMin = long.MaxValue;

        long lastHoldTime = 0;

        var diff = _time;
        var op = 1;

        var seen = new List<long>();

        do 
        {
            var halfTime = (diff / 2) + (diff % 2);
            var holdTime = lastHoldTime + op * halfTime;
            var travel = holdTime * (_time - holdTime);
            
            // Console.WriteLine($"{lastHoldTime} + {op} * (({diff} / 2) + ({diff} % 2)) = {holdTime} => {travel}");

            if (seen.Contains(holdTime)) break;
            seen.Add(holdTime);

            diff = halfTime;
            lastHoldTime = holdTime;

            if (travel > _distance) {
                winMax = long.Max(winMax, holdTime);
                winMin = long.Min(winMin, holdTime);
                op = -1;
            } else {
                op = 1;
            }
        }
        while (true);

        winMax = winMax + (winMax - winMin) - _time % 2;
        // Console.WriteLine($"{winMax} :: {winMin}");
        return winMax - winMin + 1;
    }

    public long GetTravelDistance(long holdTime)
    {
        var travel = holdTime * (_time - holdTime);
        // Console.WriteLine($"{holdTime} => {travel}");
        return travel;
    }
}