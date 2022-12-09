string[] lines = File.ReadAllLines("puzzleInput.txt");

int[][] forest = lines
    .Select(line => line
        .Select(ch => int.Parse(ch.ToString()))
        .ToArray())
    .ToArray();

int firstPartResult = ((forest.Length + forest[0].Length) * 2) - 4;
int secondPartResult = 0;

for (int i = 1; i < forest.Length - 1; i++)
{
    for (int j = 1; j < forest[i].Length - 1; j++)
    {
        if (IsVisibleFromAnywhere((i, j), forest))
        {
            firstPartResult++;
        }
    }
}

for (int i = 1; i < forest.Length - 1; i++)
{
    for (int j = 1; j < forest[i].Length - 1; j++)
    {
        int scenicScore = CountTreeScenicScore((i, j), forest);
        if (scenicScore > secondPartResult)
        {
            secondPartResult = scenicScore;
        }
    }
}

Console.WriteLine(firstPartResult);
Console.WriteLine(secondPartResult);

bool IsVisibleFromAnywhere((int i, int j) position, int[][] forest) =>
    IsVisibleFromNorth(position, forest) ||
    IsVisibleFromSouth(position, forest) ||
    IsVisibleFromWest(position, forest) ||
    IsVisibleFromEast(position, forest);

bool IsVisibleFromNorth((int i, int j) position, int[][] forest)
{
    for (int i = position.i - 1; i >= 0; i--)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[i][position.j];

        if (selfHeight <= checkingHeight)
        {
            return false;
        }
    }

    return true;
}

bool IsVisibleFromSouth((int i, int j) position, int[][] forest)
{
    for (int i = position.i + 1; i < forest.Length; i++)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[i][position.j];

        if (selfHeight <= checkingHeight)
        {
            return false;
        }
    }

    return true;
}

bool IsVisibleFromWest((int i, int j) position, int[][] forest)
{
    for (int j = position.j - 1; j >= 0; j--)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[position.i][j];

        if (selfHeight <= checkingHeight)
        {
            return false;
        }
    }

    return true;
}

bool IsVisibleFromEast((int i, int j) position, int[][] forest)
{
    for (int j = position.j + 1; j < forest[position.i].Length; j++)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[position.i][j];

        if (selfHeight <= checkingHeight)
        {
            return false;
        }
    }

    return true;
}


int CountTreeScenicScore((int i, int j) position, int[][] forest) =>
    CountScenicScoreFromNorth(position, forest) *
    CountScenicScoreFromSouth(position, forest) *
    CountScenicScoreFromWest(position, forest) *
    CountScenicScoreFromEast(position, forest);

int CountScenicScoreFromNorth((int i, int j) position, int[][] forest)
{
    int scenicScore = 0;
    for (int i = position.i - 1; i >= 0; i--)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[i][position.j];

        scenicScore += 1;

        if (selfHeight <= checkingHeight)
        {
            return scenicScore;
        }
    }

    return scenicScore;
}

int CountScenicScoreFromSouth((int i, int j) position, int[][] forest)
{
    int scenicScore = 0;
    for (int i = position.i + 1; i < forest.Length; i++)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[i][position.j];

        scenicScore += 1;

        if (selfHeight <= checkingHeight)
        {
            return scenicScore;
        }
    }

    return scenicScore;
}

int CountScenicScoreFromWest((int i, int j) position, int[][] forest)
{
    int scenicScore = 0;
    for (int j = position.j - 1; j >= 0; j--)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[position.i][j];

        scenicScore += 1;

        if (selfHeight <= checkingHeight)
        {
            return scenicScore;
        }
    }

    return scenicScore;
}

int CountScenicScoreFromEast((int i, int j) position, int[][] forest)
{
    int scenicScore = 0;
    for (int j = position.j + 1; j < forest[position.i].Length; j++)
    {
        int selfHeight = forest[position.i][position.j];
        int checkingHeight = forest[position.i][j];

        scenicScore += 1;

        if (selfHeight <= checkingHeight)
        {
            return scenicScore;
        }
    }

    return scenicScore;
}