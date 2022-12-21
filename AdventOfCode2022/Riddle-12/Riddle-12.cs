namespace AdventOfCode2022
{
    using Interfaces;

    public class Riddle12 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public Map Map { get; set; }

        public string SolutionA => "423";

        public string SolutionB => "416";

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
                            Map.Graph[x, y] = new Knot()
                            {
                                X = x,
                                Y = y,
                                Heigh = 0,
                            };
                            Map.Start = Map.Graph[x, y];
                            break;
                        case 'E':
                            Map.Graph[x, y] = new Knot()
                            {
                                X = x,
                                Y = y,
                                Heigh = 25,
                            };
                            Map.End = Map.Graph[x, y];

                            break;
                        default:
                            Map.Graph[x,y] = new Knot()
                            {
                                X = x,
                                Y = y,
                                Heigh = line[x] - 'a',
                            };
                            break;
                    }
                }
                y++;
            }
        }

        private void Calculate()
        {
            Map.Dijkstra();
            Map.Write();
            ResultA = $"{Map.End.Distance}";

            Map.Start = Map.Graph[0, 13];
            Map.Dijkstra();
            Map.Write();
            ResultB = $"{Map.End.Distance}";

            //int shortestDistance = int.MaxValue;
            //int i = 0;
            //foreach (var knot in Map.Graph)
            //{
            //    if (knot.Heigh == 0 && knot.X < 14)
            //    {
            //        i++;

            //        Map.Start = knot;
            //        Map.Dijkstra();

            //        if (Map.End.Distance < shortestDistance)
            //        {
            //            shortestDistance = Map.End.Distance;
            //            Console.WriteLine(i + ": (" + Map.Start.X + " | " + Map.Start.Y + ") " + Map.End.Distance);
            //            Map.Write();
            //        }
            //    }
            //}

            //ResultB = $"{shortestDistance}";
        }
    }
}