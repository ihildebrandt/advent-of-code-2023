namespace AdventOfCode;

public static class Enumerator
{
    public static IEnumerable<string> EnumerateTextReader(TextReader reader)
    {
        string? line = null;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Trim() == "<EOF>") break;
            yield return line;
        }
    }
}