int firstPartResult = 0;
int secondPartResult = 0;

foreach (var line in File.ReadLines("puzzleInput.txt"))
{
    var numbers = line.Split(',').SelectMany(pair => pair.Split('-').Select(int.Parse)).ToArray();

    (int start, int end) firstPair = (numbers[0], numbers[1]);
    (int start, int end) secondPair = (numbers[2], numbers[3]);

    if (IsNumberInRange(firstPair.start, secondPair) && IsNumberInRange(firstPair.end, secondPair) ||
        IsNumberInRange(secondPair.start, firstPair) && IsNumberInRange(secondPair.end, firstPair))
    {
        firstPartResult++;
    }
}

foreach (var line in File.ReadLines("puzzleInput.txt"))
{
    var numbers = line.Split(',').SelectMany(pair => pair.Split('-').Select(int.Parse)).ToArray();

    (int start, int end) firstPair = (numbers[0], numbers[1]);
    (int start, int end) secondPair = (numbers[2], numbers[3]);

    if (IsNumberInRange(firstPair.start, secondPair) || IsNumberInRange(firstPair.end, secondPair) ||
        IsNumberInRange(secondPair.start, firstPair) || IsNumberInRange(secondPair.end, firstPair))
    {
        secondPartResult++;
    }
}

Console.WriteLine($"First part result: {firstPartResult}");
Console.WriteLine($"First part result: {secondPartResult}");

static bool IsNumberInRange(int number, (int Start, int End) range) 
    => range.Start <= number && number <= range.End;