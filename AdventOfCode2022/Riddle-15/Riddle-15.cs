namespace AdventOfCode2022
{
    using Interfaces;

    public class Riddle15: ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "4717631";

        public string SolutionB => "???";

        public BeaconMap Map { get; set; }

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
            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-15\\Input15.txt"))
            {
                var split = line.Split(':');
                
                var sensor = GetCoords(split[0]);
                var beacon = GetCoords(split[1]);

                Map.Add(new SensorReport
                (
                    sensor: new Sensor 
                    { 
                        X = sensor.x, 
                        Y = sensor.y 
                    }, 
                    beacon: new Beacon 
                    { 
                        X = beacon.x, 
                        Y = beacon.y 
                    } 
                ));
            }
        }

        private static (int x, int y) GetCoords(string input)
        {
            var split = input.Split(", ");

            return (int.Parse(split[0].Split('=')[1]), int.Parse(split[1].Split('=')[1]));
        }

        private void Calculate()
        {
            ResultA = $"{Map.Calculate(2_000_000)}";
            ResultB = $"{SolutionB}";
        }
    }
}