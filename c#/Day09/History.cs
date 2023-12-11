namespace Day09;

public class History
{
    public static long CalculateStep(string line, bool forward = true)
    {
        var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        var regression = new List<List<int>> { nums };

        do 
        {
            var lastRegression = regression[regression.Count - 1];
            nums = new List<int>();

            for (var i = 1; i < lastRegression.Count; i++) 
            {
                nums.Add(lastRegression[i] - lastRegression[i - 1]);
            }
            regression.Add(nums);
        }
        while(nums.Sum() != 0);

        if (forward) 
        {
            regression[regression.Count - 1].Add(0);
            for (var i = regression.Count - 1; i > 0; i--)
            {
                var current = regression[i];
                var prior = regression[i - 1];
                
                var lastCurrentStep = current[current.Count - 1];
                var lastPriorStep = prior[prior.Count - 1];
                prior.Add(lastPriorStep + lastCurrentStep);
            }
        }
        else
        {
            regression[regression.Count - 1].Insert(0, 0);
            for (var i = regression.Count - 1; i > 0; i--)
            {
                var current = regression[i];
                var prior = regression[i - 1];

                var lastCurrentStep = current[0];
                var lastPriorStep = prior[0];
                prior.Insert(0, lastPriorStep - lastCurrentStep);
            }
        }

        return regression[0].First();
    }
}