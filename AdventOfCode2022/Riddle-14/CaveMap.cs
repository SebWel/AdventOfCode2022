using System.IO;

namespace AdventOfCode2022
{
    public class CaveMap
    {
        public List<PathInstruction> Paths { get; set; }

        public List<Coordinate> Coordinates { get; set; }

        public Coordinate Source { get; set; }

        public int BadRock { get; set; }

        public CaveMap()
        {
            Source = new SandSource { X = 500, Y = 0 };

            Paths = new();
            Coordinates = new();
            Coordinates.Add(Source);
        }

        public void Add(PathInstruction instruction)
        {
            Paths.Add(instruction);

            if (instruction.Start.X == instruction.End.X)
            {
                int maxY = Math.Max(instruction.Start.Y, instruction.End.Y);
                int minY = Math.Min(instruction.Start.Y, instruction.End.Y);

                for (int y = minY; y <= maxY; y++)
                {
                    if (!Coordinates.Any(c => c.X == instruction.Start.X && c.Y == y))
                        Coordinates.Add(new Rock { X = instruction.Start.X, Y = y });
                }
            }

            if (instruction.Start.Y == instruction.End.Y)
            {
                int maxX = Math.Max(instruction.Start.X, instruction.End.X);
                int minX = Math.Min(instruction.Start.X, instruction.End.X);

                for (int x = minX; x <= maxX; x++)
                {
                    if (!Coordinates.Any(c => c.X == x && c.Y == instruction.Start.Y))
                        Coordinates.Add(new Rock { X = x, Y = instruction.Start.Y });
                }
            }
        }

        public void Trickle(out int a, out int b)
        {
            a = 0;
            b = 0;

            BadRock = Coordinates.Max(y => y.Y) + 2;

            int count = 0;
            while (true)
            {
                var sand = new Sand { X = Source.X, Y = Source.Y };
                while (true)
                {
                    if (TryMoveDown(sand))
                        continue;
                    if (TryMoveLeft(sand))
                        continue;
                    if (TryMoveRight(sand))
                        continue;

                    if (a == 0 && sand.Y == BadRock - 1)
                    {
                        a = count;
                    }

                    if (b == 0 && sand.X == Source.X && sand.Y == Source.Y)
                    {
                        b = count + 1;
                        return;
                    }

                    break;
                }

                count++;
                Coordinates.Add(sand);
                //Print(count);
            }
        }

        public bool TryMoveDown(Sand sand)
        {
            if (sand.Y + 1 == BadRock)
                return false;

            if (Coordinates.Any(c => c.X == sand.X && c.Y == sand.Y + 1))
                return false;

            sand.Y++;
            return true;
        }

        public bool TryMoveLeft(Sand sand)
        {
            if (sand.Y + 1 == BadRock)
                return false;

            if (Coordinates.Any(c => c.X == sand.X - 1 && c.Y == sand.Y + 1))
                return false;

            sand.X--;
            sand.Y++;
            return true;
        }

        public bool TryMoveRight(Sand sand)
        {
            if (sand.Y + 1 == BadRock)
                return false;

            if (Coordinates.Any(c => c.X == sand.X + 1 && c.Y == sand.Y + 1))
                return false;

            sand.X++;
            sand.Y++;
            return true;
        }

        public void Print(int iteration)
        {
            Thread.Sleep(100);

            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            Console.WriteLine();
            Console.WriteLine(iteration);

            int minX = Coordinates.Min(x => x.X);
            int maxX = Coordinates.Max(x => x.X);
            int minY = Coordinates.Min(y => y.Y);
            int maxY = Coordinates.Max(y => y.Y) + 2;

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    switch (Coordinates.FirstOrDefault(c => c.X == x && c.Y == y))
                    {
                        case null:
                            Console.Write('.');
                            break;
                        case SandSource:
                            Console.Write('+');
                            break;
                        case Rock:
                            Console.Write('#');
                            break;
                        case Sand:
                            Console.Write('o');
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
