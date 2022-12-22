namespace AdventOfCode2022
{
    using Interfaces;

    public class Riddle14 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "618";

        public string SolutionB => "???";

        public CaveMap Map { get; set; }

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
            var start = new Coordinate();
            var end = new Coordinate();

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-14\\Input14.txt"))
            {
                var coordinates = line.Split(" -> ");

                for (int i = 0; i < coordinates.Length; i++)
                {
                    var coordinate = coordinates[i].Split(',');
                    var x = int.Parse(coordinate[0]);
                    var y = int.Parse(coordinate[1]);

                    var newCoordinate = new Coordinate { X = x, Y = y };

                    if (i % 2 == 0)
                        start = newCoordinate;
                    else
                        end = newCoordinate;

                    if (i == 0)
                        continue;

                    Map.Add(new PathInstruction { Start = start, End = end });
                }
            }
        }

        private void Calculate()
        {
            ResultA = $"{Map.Trickle()}";
            ResultB = $"{SolutionB}";
        }
    }
}