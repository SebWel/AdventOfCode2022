namespace AdventOfCode2022
{
    public interface IFileSystem
    {
        string Name { get; }

        int Size { get; }
    }

    public class Dir : IFileSystem
    {
        public Dir Parent { get; set; }

        public string Name { get; set; }

        private List<IFileSystem> Children { get; set; } = new List<IFileSystem>();

        public IEnumerable<Dir> Dirs => Children.OfType<Dir>().SelectMany(c => c.Dirs).Append(this);

        public Dir CD(string name)
        {
            return Children.OfType<Dir>().Single(c => c.Name == name);
        }

        public int Size => Children.Sum(c => c.Size);

        public void Add(IFileSystem fileSystem)
        {
            Children.Add(fileSystem);
        }
    }

    public class Data : IFileSystem
    {
        public string Name { get; set; }

        public int Size { get; set; }
    }
}
