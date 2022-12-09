namespace Day7_NoSpaceLeftOnDevice;

internal class FileSystemNode
{
    protected ElfDir? parent = null;

    public FileSystemNode(ElfDir? parent = null)
    {
        if (parent is not null)
        {
            this.parent = parent;
        }
    }

    public string Name { get; set; } = string.Empty;

    public ElfDir? Parent => parent;
}
