int[] topThree = { 0, 0, 0 };
var current = 0;

foreach (string line in File.ReadLines("calories.txt"))
{
    if (int.TryParse(line, out int value))
    {
        current += value;
        continue;
    }

    if (current > topThree.FirstOrDefault())
    {
        topThree[0] = current;
        Array.Sort(topThree);
    }

    current = 0;
}

Console.WriteLine($"First part result: {topThree.Last()}");
Console.WriteLine($"Second part result: {topThree.Sum()}");