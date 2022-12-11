namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle10 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "15880";

        public string SolutionB => "???";

        public int[] SignalStrenghts { get; set; }

        public ISolvable Solve()
        {
            Construct();
            Parse();
            Calculate();

            return this;
        }

        private void Construct()
        {
            SignalStrenghts = new int[250];
        }

        private void Parse()
        {
            int x = 1;
            int cycle = 1;

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-10\\Input10.txt"))
            {
                switch(line)
                {
                    case "noop":
                        SignalStrenghts[cycle] = cycle * x;
                        cycle++;
                        break;
                    case string s when s.StartsWith("addx "):
                        int i = int.Parse(line.Split(' ')[1]);
                        SignalStrenghts[cycle] = cycle * x;
                        cycle++;
                        SignalStrenghts[cycle] = cycle * x;
                        cycle++;
                        x += i;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void Calculate()
        {
            ResultA = $"{SignalStrenghts[20] + SignalStrenghts[60] + SignalStrenghts[100] + SignalStrenghts[140] + SignalStrenghts[180] + SignalStrenghts[220]}";
            ResultB = $"{SolutionB}";
        }
    }
}