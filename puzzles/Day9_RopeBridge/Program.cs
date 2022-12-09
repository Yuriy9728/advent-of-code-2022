using System.Reflection;

HashSet<(int X, int Y)> tailVisitedPositions = new();

(int X, int Y)[] rope = new (int X, int Y)[10].Select(node => (0, 0)).ToArray();

foreach (var line in File.ReadLines("puzzleInput.txt"))
{
    var splittedLine = line.Split(' ');
    var direction = splittedLine[0];
    var numberOfSteps = int.Parse(splittedLine[1]);

    if (direction == "U")
    {
        for (int i = 0; i < numberOfSteps; i++)
        {
            tailVisitedPositions.Add(rope.Last());
            rope[0].Y -= 1;
            MoveRopeNodes(rope);
        }
    }
    else if (direction == "R")
    {
        for (int i = 0; i < numberOfSteps; i++)
        {
            tailVisitedPositions.Add(rope.Last());
            rope[0].X += 1;
            MoveRopeNodes(rope);
        }
    }
    else if (direction == "D")
    {
        for (int i = 0; i < numberOfSteps; i++)
        {
            tailVisitedPositions.Add(rope.Last());
            rope[0].Y += 1;
            MoveRopeNodes(rope);
        }
    }
    else if (direction == "L")
    {
        for (int i = 0; i < numberOfSteps; i++)
        {
            tailVisitedPositions.Add(rope.Last());
            rope[0].X -= 1;
            MoveRopeNodes(rope);
        }
    }
}

tailVisitedPositions.Add(rope.Last());

Console.WriteLine(tailVisitedPositions.Count);

static void MoveRopeNodes((int X, int Y)[] rope)
{
    for (int i = 0; i < rope.Length - 1; i++)
    {
        MoveTail(rope[i], ref rope[i + 1]);
    }
}

static void MoveTail((int X, int Y) headPosition, ref (int X, int Y) tailPosition)
{
    if (Math.Abs(headPosition.X - tailPosition.X) <= 1 && Math.Abs(headPosition.Y - tailPosition.Y) <= 1)
    {
        return;
    }

    if (headPosition.X > tailPosition.X)
    {
        tailPosition.X += 1;
    }
    else if (headPosition.X < tailPosition.X)
    {
        tailPosition.X -= 1;
    }

    if (headPosition.Y > tailPosition.Y)
    {
        tailPosition.Y += 1;
    }
    else if (headPosition.Y < tailPosition.Y)
    {
        tailPosition.Y -= 1;
    }
}