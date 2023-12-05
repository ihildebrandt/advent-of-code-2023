var numbers = new [] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

string? line = null;
int accumulator = 0;

while ((line = Console.In.ReadLine()) != null) 
{
    int firstIndex = int.MaxValue;
    int firstDigit = 0;
    int lastIndex = int.MinValue;
    int lastDigit = 0;

    for (var n = 0; n < numbers.Length; n++) {
        int index = line.IndexOf(numbers[n]);

        if (index > -1 && index < firstIndex) {
            firstIndex = index;
            firstDigit = n + 1;
        }

        index = line.LastIndexOf(numbers[n]);
        if (index > -1 && index > lastIndex) {
            lastIndex = index; 
            lastDigit = n + 1;
        }
    }

    for(var i = 0; i < line.Length; i++) {
        if (int.TryParse(line[i].ToString(), out var testDigit)) {
            if (i < firstIndex) {
                firstDigit = testDigit;
            }
            break;
        }
    }

    for (var j = line.Length - 1; j >= 0; j--) {
        if (int.TryParse(line[j].ToString(), out var testDigit)) {
            if (j > lastIndex) {
                lastDigit = testDigit;
            }
            break;
        }
    }

    Console.WriteLine(line + " " + firstDigit + lastDigit);
    accumulator += firstDigit * 10 + lastDigit;
}

Console.WriteLine(accumulator);