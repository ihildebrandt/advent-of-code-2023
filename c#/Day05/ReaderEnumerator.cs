using System.Collections;

namespace Day05;

public class Reader
{
    public static IEnumerable<string> ReadEnumerable(TextReader reader)
    {
        string? line = null;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Trim() == "<EOF>") break;
            yield return line;
        }
    }
}
