namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle07 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public Dir RootDir { get; set; }

        public string SolutionA => "1749646";

        public string SolutionB => "1498966";

        public ISolvable Solve()
        {
            Parse();
            Calculate();

            return this;
        }

        private void Parse()
        {
            Dir currentDir = null; 
            
            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-07\\Input07.txt"))
            {
                switch (line)
                {
                    case "$ cd /":
                        var rootDir = new Dir{ Name = "/", Parent = null};
                        RootDir = rootDir;
                        currentDir = rootDir;
                        break;
                    case "$ cd ..":
                        currentDir = currentDir.Parent;
                        break;
                    case string s when s.StartsWith("$ cd "):
                        currentDir = currentDir.CD(s.Substring(5));
                        break;
                    case "$ ls":
                        break;
                    case string s when s.StartsWith("dir "):
                        currentDir.Add(new Dir { Name = s.Substring(4), Parent = currentDir });
                        break;
                    default:
                        var split = line.Split(' ');
                        currentDir.Add(new Data { Name = split[1], Size = int.Parse(split[0])});
                        break;
                }
            }
        }

        private void Calculate()
        {
            int requiredSize = RootDir.Size + 30000000 - 70000000;
            var all = RootDir.Dirs.OrderBy(c => c.Size).ToList();
            
            ResultA = $"{all.Where(c => c.Size <= 100000).Sum(s => s.Size)}";
            ResultB = $"{all.First(d => d.Size > requiredSize).Size}";
        }
    }
}
