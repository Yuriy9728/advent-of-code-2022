using var textReader = File.OpenText("puzzleInput.txt");

var declaration = GetStacksDeclaration(textReader);

Stack<char>[] firstPartStacks = ParseStacksDeclaration(declaration).ToArray();
Stack<char>[] secondPartStacks = ParseStacksDeclaration(declaration).ToArray();

var commands = GetCargoCommands(textReader).ToArray();

foreach ((int Count, int From, int To) in commands)
{
    for (int i = 0; i < Count; i++)
    {
        var poped = firstPartStacks[From].Pop();
        firstPartStacks[To].Push(poped);
    }
}

foreach ((int Count, int From, int To) in commands)
{
    List<char> buffer = new(Count);
    for (int i = 0; i < Count; i++)
    {
        buffer.Add(secondPartStacks[From].Pop());
    }
    for (int i = 0; i < Count; i++)
    {
        secondPartStacks[To].Push(buffer[^(i + 1)]);
    }
}

foreach (var stack in firstPartStacks)
{
	Console.Write(stack.Peek());
}

Console.WriteLine();

foreach (var stack in secondPartStacks)
{
    Console.Write(stack.Peek());
}

string[] GetStacksDeclaration(StreamReader textReader)
{
    string line = textReader.ReadLine()!;

    List<string> declaration = new();

    while (!string.IsNullOrWhiteSpace(line))
    {
        declaration.Add(line);
        line = textReader.ReadLine()!;
    }
    declaration.Remove(declaration.Last());

    return declaration.ToArray();
}

Stack<char>[] ParseStacksDeclaration(IEnumerable<string> declaration)
{
    int numberOfStacks = (declaration.First().Length / 4) + 1;
    var stacks = new Stack<char>[numberOfStacks].Select(stack => new Stack<char>()).ToArray();

    foreach (var line in declaration.Reverse<string>())
    {
        int stackNumber = 0;

        for (int i = 1; i < line.Length - 1; i += 4)
        {
            if (!char.IsWhiteSpace(line[i]))
            {
                stacks[stackNumber].Push(line[i]);
            }

            stackNumber++;
        }
    }

    return stacks;
}
IEnumerable<(int Count, int From, int To)> GetCargoCommands(StreamReader textReader)
{
    while (!textReader.EndOfStream)
    {
        var line = textReader.ReadLine()!;
        var numbers = line.Split(' ').Where(subStr => char.IsDigit(subStr[0])).Select(int.Parse).ToArray();

        yield return (numbers[0], numbers[1] - 1, numbers[2] - 1);
    }
}
