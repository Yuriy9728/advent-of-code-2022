Dictionary<char, Shape> charShapes = new()
{
    { 'A', Shape.Rock },
    { 'X', Shape.Rock },
    { 'B', Shape.Paper },
    { 'Y', Shape.Paper },
    { 'C', Shape.Scissors },
    { 'Z', Shape.Scissors },
};

Dictionary<char, Result> charResults = new()
{
    { 'X', Result.Lose },
    { 'Y', Result.Draw },
    { 'Z', Result.Win },
};

int firstResult = 0;
int secondResult = 0;

foreach (string line in File.ReadLines("puzzleInput.txt"))
{
    firstResult += GetScoreByShapes(charShapes[line.Last()], charShapes[line.First()]);
}

foreach (string line in File.ReadLines("puzzleInput.txt"))
{
    secondResult += GetScoreByResultAndShape(charResults[line.Last()], charShapes[line.First()]);
}

Console.WriteLine($"First part result: {firstResult}");
Console.WriteLine($"Second part result: {secondResult}");

static int GetScoreByShapes(Shape ownShape, Shape opponentShape)
{
    Result result = (ownShape, opponentShape) switch
    {
        (Shape.Rock, Shape.Paper) => Result.Lose,
        (Shape.Paper, Shape.Scissors) => Result.Lose,
        (Shape.Scissors, Shape.Rock) => Result.Lose,

        (Shape.Rock, Shape.Rock) => Result.Draw,
        (Shape.Paper, Shape.Paper) => Result.Draw,
        (Shape.Scissors, Shape.Scissors) => Result.Draw,

        (Shape.Rock, Shape.Scissors) => Result.Win,
        (Shape.Paper, Shape.Rock) => Result.Win,
        (Shape.Scissors, Shape.Paper) => Result.Win,
        _ => Result.Lose
    };

    return (int)result + (int)ownShape;
}

static int GetScoreByResultAndShape(Result expectedResult, Shape opponentShape)
{
    Shape ownShape = (expectedResult, opponentShape) switch
    {
        (Result.Lose, Shape.Paper) => Shape.Rock,
        (Result.Lose, Shape.Scissors) => Shape.Paper,
        (Result.Lose, Shape.Rock) => Shape.Scissors,

        (Result.Draw, Shape.Rock) => Shape.Rock,
        (Result.Draw, Shape.Paper) => Shape.Paper,
        (Result.Draw, Shape.Scissors) => Shape.Scissors,

        (Result.Win, Shape.Scissors) => Shape.Rock,
        (Result.Win, Shape.Rock) => Shape.Paper,
        (Result.Win, Shape.Paper) => Shape.Scissors,
        _ => Shape.None
    };

    return (int)ownShape + (int)expectedResult;
}

enum Shape
{
    None = 0,   
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

enum Result
{
    Lose = 0,
    Draw = 3,
    Win = 6
}
