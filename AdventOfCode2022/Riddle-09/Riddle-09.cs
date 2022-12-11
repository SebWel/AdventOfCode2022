namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle09 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "6745";

        public string SolutionB => "2793";

        public Knot Head { get; set; }

        public Tail Tail1 { get; set; }

        public Tail Tail2 { get; set; }

        public Tail Tail3 { get; set; }

        public Tail Tail4 { get; set; }

        public Tail Tail5 { get; set; }

        public Tail Tail6 { get; set; }

        public Tail Tail7 { get; set; }

        public Tail Tail8 { get; set; }

        public Tail Tail9 { get; set; }

        public ISolvable Solve()
        {
            Construct();
            Parse();
            Calculate();

            return this;
        }

        private void Construct()
        {
            Head = new Knot { Parent = null };
            Tail1 = new Tail { Parent = Head, VisitedCoordinates = new List<Coordinate> { new Coordinate() } };
            Tail2 = new Tail { Parent = Tail1 };
            Tail3 = new Tail { Parent = Tail2 };
            Tail4 = new Tail { Parent = Tail3 };
            Tail5 = new Tail { Parent = Tail4 };
            Tail6 = new Tail { Parent = Tail5 };
            Tail7 = new Tail { Parent = Tail6 };
            Tail8 = new Tail { Parent = Tail7 };
            Tail9 = new Tail { Parent = Tail8, VisitedCoordinates = new List<Coordinate> { new Coordinate() } };
        }

        private void Parse()
        {
            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-09\\Input09.txt"))
            {
                var split = line.Split(" ");
                var direction = split[0][0];
                int count = int.Parse(split[1]);

                for (int i = 0; i < count; i++)
                {
                    switch (direction)
                    {
                        case 'R':
                            Head.X += 1;
                            break;
                        case 'L':
                            Head.X -= 1;
                            break;
                        case 'U':
                            Head.Y += 1;
                            break;
                        case 'D':
                            Head.Y -= 1;
                            break;
                        default: throw new NotImplementedException();
                    }
                    
                    Tail1.Follow();
                    Tail2.Follow();
                    Tail3.Follow();
                    Tail4.Follow();
                    Tail5.Follow();
                    Tail6.Follow();
                    Tail7.Follow();
                    Tail8.Follow();
                    Tail9.Follow();
                }
            }
        }

        private void Calculate()
        {
            ResultA = $"{Tail1.VisitedCoordinates.Count()}";
            ResultB = $"{Tail9.VisitedCoordinates.Count()}";
        }
    }
}