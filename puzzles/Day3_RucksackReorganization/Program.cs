using System.Collections.Immutable;

int firstResult = 0;
int secondResult = 0;

ImmutableArray<int> charCodes = Enumerable
    .Concat(Enumerable.Range('a', 26), Enumerable.Range('A', 26))
    .ToImmutableArray();

ImmutableDictionary<char, int> charPriorities = charCodes
    .ToImmutableDictionary(charCode => (char)charCode, charCode => charCodes.IndexOf(charCode) + 1);

Dictionary<char, int> charCount = charCodes
    .ToDictionary(charCode => (char)charCode, count => 0);

List<string> group = new();

foreach (string line in File.ReadLines("puzzleInput.txt"))
{
    var compartments = line.Chunk(line.Length / 2);
    var item = Enumerable.Intersect(compartments.First(), compartments.Last()).Single();
    charCount[item] += charPriorities[item];
}

firstResult = charCount.Sum(keyValuePair => keyValuePair.Value);

foreach (string line in File.ReadLines("puzzleInput.txt"))
{
    if (group.Count >= 3)
    {
        var badgeItem = group[0].Intersect(group[1].Intersect(group[2])).Single();
        secondResult += charPriorities[badgeItem];

        group.Clear();
    }

    group.Add(line);
}

secondResult += charPriorities[group[0].Intersect(group[1].Intersect(group[2])).Single()];

Console.WriteLine($"First part result: {firstResult}");

Console.WriteLine($"First part result: {secondResult}");