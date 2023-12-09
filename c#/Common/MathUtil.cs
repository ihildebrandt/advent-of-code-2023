namespace AdventOfCode;

public static class MathUtil
{
    public static long[] GetPrimeFactors(long n)
    {
        var sqrt = Math.Sqrt(n);
        var factors = new List<long>();

        while (n % 2 == 0)
        {
            factors.Add(2);
            n /= 2;
        }

        for (var d = 3; d <= sqrt; d+=2)
        {
            while (n % d == 0)
            {
                factors.Add(d);
                n /= d;
            }
        }

        if (n > 2)
        {
            factors.Add(n);
        }

        return factors.ToArray();
    }

    public static long GetLeastCommonMultiple(IEnumerable<IEnumerable<long>> factors)
    {
        var primes = new List<long>();
        foreach (var entry in factors)
        {
            foreach (var factor in entry)
            {
                if (!primes.Contains(factor))
                {
                    primes.Add(factor);
                }
            }
        }

        return primes.Aggregate((a, b) => a * b);
    }
}