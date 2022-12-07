using var textReader = File.OpenText("puzzleInput.txt");

int numberOfChars = 14;

Queue<char> sequence = new(numberOfChars);

for (int i = 0; i < numberOfChars; i++)
{
    sequence.Enqueue((char)textReader.Read());
}

int currentChar = numberOfChars;

while (sequence.Distinct().Count() < numberOfChars && !textReader.EndOfStream)
{
    sequence.Enqueue((char)textReader.Read());
    sequence.Dequeue();
    currentChar++;
}

Console.WriteLine(currentChar);