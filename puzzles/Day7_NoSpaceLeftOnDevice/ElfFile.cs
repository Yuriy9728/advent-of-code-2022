namespace Day7_NoSpaceLeftOnDevice;

internal class ElfFile : FileSystemNode
{
    public ElfFile(string fileName, long size, ElfDir? parent = null) : base(parent)
    {
        Name = fileName;
        Size = size;
    }

    public long Size { get; }
}
