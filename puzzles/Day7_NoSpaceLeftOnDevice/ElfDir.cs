namespace Day7_NoSpaceLeftOnDevice;

internal class ElfDir : FileSystemNode
{
    private readonly List<ElfDir> childDirectories = new();
	private readonly List<ElfFile> childFiles = new();

	public ElfDir(string directoryName, ElfDir? parent = null) : base(parent)
	{
		Name = directoryName;
	}

	public void AddDir(ElfDir dir)
	{
		childDirectories.Add(dir);
	}

	public void AddFile(ElfFile file)
	{
		childFiles.Add(file);
	}

	public bool ContainsFile(string dirName)
	{
		foreach (var dir in childDirectories)
		{
			if (dirName == dir.Name)
			{
				return true;
			}
		}

		return false;
	}

    public bool ContainsDir(string fileName)
    {
        foreach (var dir in childFiles)
        {
            if (fileName == dir.Name)
            {
                return true;
            }
        }

        return false;
    }

	public IEnumerable<ElfDir> GetChildDirs()
	{
		List<ElfDir> dirs = new();

		if (childDirectories.Count > 0)
		{
            dirs.AddRange(childDirectories);
            foreach (var subDir in childDirectories)
			{
				dirs.AddRange(subDir.GetChildDirs());
			}
		}

		return dirs;
	}

	public ElfDir? GetDir(string dirName)
	{
        foreach (var dir in childDirectories)
        {
            if (dirName == dir.Name)
            {
                return dir;
            }
        }

		return null;
    }

    public long CountSize()
	{
		long size = 0;

		foreach (var file in childFiles)
		{
			size += file.Size;
		}

		foreach (var dir in childDirectories)
		{
			size += dir.CountSize();
		}

		return size;
	}
}
