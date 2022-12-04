int firstResult = 0;
int secondResult = 0;

await foreach (var line in File.ReadLinesAsync("puzzleInput.txt"))
{
    var numbers = line.Split(',').SelectMany(pair => pair.Split('-').Select(int.Parse)).ToArray();

    (int start, int end) firstPair = (numbers[0], numbers[1]);
    (int start, int end) secondPair = (numbers[2], numbers[3]);

    if (IsNumberInRange(firstPair.start, secondPair) && IsNumberInRange(firstPair.end, secondPair) ||
        IsNumberInRange(secondPair.start, firstPair) && IsNumberInRange(secondPair.end, firstPair))
    {
        firstResult++;
    }
}

await foreach (var line in File.ReadLinesAsync("puzzleInput.txt"))
{
    var numbers = line.Split(',').SelectMany(pair => pair.Split('-').Select(int.Parse)).ToArray();

    (int start, int end) firstPair = (numbers[0], numbers[1]);
    (int start, int end) secondPair = (numbers[2], numbers[3]);

    if (IsNumberInRange(firstPair.start, secondPair) || IsNumberInRange(firstPair.end, secondPair) ||
        IsNumberInRange(secondPair.start, firstPair) || IsNumberInRange(secondPair.end, firstPair))
    {
        secondResult++;
    }
}

Console.WriteLine($"First part result: {firstResult}");
Console.WriteLine($"First part result: {secondResult}");

static bool IsNumberInRange(int number, (int Start, int End) range)
    => range.Start <= number && number <= range.End;