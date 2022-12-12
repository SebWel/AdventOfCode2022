namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle10 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "15880";

        public string SolutionB => "PLGFKAZG";

        public int[] SignalStrenghts { get; set; }

        public ISolvable Solve()
        {
            Construct();
            Parse();
            Calculate();
            Render();

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
                        SignalStrenghts[cycle] = cycle * x;
                        cycle++;
                        SignalStrenghts[cycle] = cycle * x;
                        cycle++;
                        x += int.Parse(line.Split(' ')[1]);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void Render()
        {
            for (int i = 0; i < 240; i++)
            {
                if (i % 40 == 0) Console.WriteLine();

                Console.Write(IsCursorVisible(i + 1) ? '#' : '.');
            }

            Console.WriteLine();
        }

        private bool IsCursorVisible(int circle)
        {
            var x = SignalStrenghts[circle] / circle;
            int linePosition = circle % 40 - 1;

            return Math.Abs(x - linePosition) < 2;
        }

        private void Calculate()
        {
            ResultA = $"{SignalStrenghts[20] + SignalStrenghts[60] + SignalStrenghts[100] + SignalStrenghts[140] + SignalStrenghts[180] + SignalStrenghts[220]}";
            ResultB = $"{SolutionB}";
        }
    }
}