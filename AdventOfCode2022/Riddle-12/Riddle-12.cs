namespace AdventOfCode2022
{
    using Interfaces;
    using System.Diagnostics;
    using System.IO;

    public class Riddle12 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public Map Map { get; set; }

        public string SolutionA => "31";

        public string SolutionB => "???";

        public ISolvable Solve()
        {
            Construct();
            Parse();
            Calculate();

            return this;
        }

        private void Construct()
        {
            Map = new();
        }

        private void Parse()
        {
            int y = 0;

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-12\\Input12.txt"))
            {
                for (int x = 0; x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case 'S':
                            Map.AddStart(y, x);
                            break;
                        case 'E':
                            Map.AddEnd(y, x);
                            break;
                        default:
                            Map.Add(y, x, line[x] - 'a');
                            break;
                    }
                }
                y++;
            }
        }

        private void Calculate()
        {
            var watch = new Stopwatch();
            watch.Start();

            Console.Clear();
            var paths = Map.Start.FindEnd(Map, new ElevationPath { Elevations = new() }.Add(Map.Start)).ToList();

            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            ResultA = $"{paths.Min(p => p.Elevations.Count()) - 1}";
            ResultB = $"{SolutionB}";
        }
    }
}