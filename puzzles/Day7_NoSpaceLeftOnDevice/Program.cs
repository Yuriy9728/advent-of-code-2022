using Day7_NoSpaceLeftOnDevice;
using System.Diagnostics.CodeAnalysis;

var rootDir = new ElfDir("/");
ElfDir? currentDir = rootDir;

foreach (var line in File.ReadLines("puzzleInput.txt"))
{
    var splittedLine = line.Split(' ');

    if (line.First() != '$')
    {
        if (char.IsLetter(line.First()))
        {
            var dirName = splittedLine.Skip(1).First();
            if (!currentDir.ContainsDir(dirName))
            {
                ElfDir newDir = new(dirName, currentDir);
                currentDir.AddDir(newDir);
            }
        }
        else if (char.IsDigit(line.First()))
        {
            var fileName = splittedLine.Skip(1).First();
            if (!currentDir.ContainsDir(fileName))
            {
                long fileSize = long.Parse(splittedLine.First());
                ElfFile newFile = new(fileName, fileSize, currentDir);
                currentDir.AddFile(newFile);
            }
        }
    }
    else if (splittedLine.Skip(1).First() == "cd")
    {
        if (splittedLine.Last() == "/")
        {
            currentDir = rootDir;
        }
        else if (splittedLine.Last() == "..")
        {
            currentDir = currentDir.Parent;
        }
        else
        {
            currentDir = currentDir.GetDir(splittedLine.Last());
        }
    }
}

long firstPartResult = 0;
long secondPartResult = 0;

foreach (var dir in rootDir.GetChildDirs())
{
    var dirSize = dir.CountSize();
    if (dirSize < 100_000)
    {
        firstPartResult += dirSize;
    }
}

long diskSpace = 70_000_000;
long needSpaceToUpdate = 30_000_000;

long rootSpaceForDelete = rootDir.CountSize() - (diskSpace - needSpaceToUpdate);

ElfDir dirWithNearestSpace = rootDir;

foreach (var dir in rootDir.GetChildDirs())
{
    var dirSize = dir.CountSize();
    if (dirSize > rootSpaceForDelete && dirSize < dirWithNearestSpace.CountSize())
    {
        dirWithNearestSpace = dir;
    }
}

secondPartResult = dirWithNearestSpace.CountSize();

Console.WriteLine(firstPartResult);
Console.WriteLine(secondPartResult);

Console.WriteLine();