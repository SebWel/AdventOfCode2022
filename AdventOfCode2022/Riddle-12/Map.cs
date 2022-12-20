namespace AdventOfCode2022
{
    public class Map
    {
        public int StartX;

        public int StartY;

        public int EndX;

        public int EndY;

        public Elevation[,] Elevations2 { get; set; }

        public Elevation Start => Elevations2[StartX, StartY];

        public Elevation End => Elevations2[EndX, EndY];

        public Map()
        {
            Elevations2 = new Elevation[144, 41];
        }

        public void AddStart(int y, int x)
        {
            Add(y, x, 0);

            StartX = x;
            StartY = y;
        }

        public void AddEnd(int y, int x)
        {
            Add(y, x, 25);

            EndX = x;
            EndY = y;
        }

        public void Add(int y, int x, int heigh)
        {
            Elevations2[x, y] = new Elevation() { X = x, Y = y, Heigh = heigh };
        }

        public IEnumerable<Elevation> FindPossibilities(int currentX, int currentY, int currentHeigh, ElevationPath path)
        {
            var north = currentY != 0 ? Elevations2[currentX, currentY - 1] : null;
            var south = currentY != Elevations2.GetLength(1) ? Elevations2[currentX, currentY + 1] : null;
            var east = currentX != Elevations2.GetLength(0) ? Elevations2[currentX + 1, currentY] : null;
            var west = currentX != 0 ? Elevations2[currentX - 1, currentY] : null;

            if (Elevation.Climbable(currentHeigh, path, east))
                yield return east;

            if (Elevation.Climbable(currentHeigh, path, south))
                yield return south;

            if (Elevation.Climbable(currentHeigh, path, north))
                yield return north;

            if (Elevation.Climbable(currentHeigh, path, west))
                yield return west;
        }

        public void Write(ElevationPath path)
        {
            //Console.Clear();
            //Thread.Sleep(100);
            Console.CursorVisible = false;

            for (int y = 0; y < 40 /* 40/5 */; y++)
            {
                for (int x = 0; x < 144 /* 144/8 */; x++)
                {
                    var element = Elevations2[x,y];

                    Console.ForegroundColor = path.Elevations.Contains(element) ? ConsoleColor.Red : ConsoleColor.White;

                    Console.SetCursorPosition(0 + x, 0 + y);
                    Console.Write((char)(element.Heigh + 'a'));
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
