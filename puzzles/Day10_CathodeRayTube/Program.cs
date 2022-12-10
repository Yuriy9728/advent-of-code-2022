int currentCycle = 0;
int X = 1;

int firstPartResult = 0;
int checkingCycle = 20;
int checkingCycleLimit = 220;

foreach (var line in File.ReadLines("puzzleInput.txt"))
{
    var command = line.Split(' ');

    if (command.First() == "noop")
    {
        CpuTickSecondPart();
    }
    else
    {
        int addX = int.Parse(command.Last());

        CpuTickSecondPart();
        CpuTickSecondPart();
        X += addX;
    }
}

Console.WriteLine(firstPartResult);

void CpuTickFirstPart()
{
    currentCycle += 1;

    if (currentCycle >= checkingCycle && currentCycle <= checkingCycleLimit)
    {
        firstPartResult += checkingCycle * X;
        checkingCycle += 40;
    }
}

void CpuTickSecondPart()
{
    currentCycle += 1;

    var crtPixelHorizontalPosition = currentCycle % 40;
    var diffBetweenPositions = Math.Abs(crtPixelHorizontalPosition - (X + 1));

    if (diffBetweenPositions <= 1)
    {
        Console.Write('#');
    }
    else
    {
        Console.Write('.');
    }

    if (currentCycle % 40 == 0)
    {
        Console.WriteLine();
    }
}