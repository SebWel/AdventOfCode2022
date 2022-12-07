namespace AdventOfCode2022
{
    using AdventOfCode2022.Interfaces;
    using System.IO;

    public class Riddle02 : ISolvable
    {
        public string ResultA { get; set; }

        public string ResultB { get; set; }

        public string SolutionA => "11841";

        public string SolutionB => "13022";

        private List<Round> Rounds = new List<Round>();

        public ISolvable Solve()
        {
            Parse();
            Calculate();
                        
            return this;
        }

        private void Parse()
        {
            Rounds.Clear();

            foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "\\Riddle-02\\Input02.txt"))
            {
                string[] x = line.Split(' ');

                Rounds.Add(new Round(x[0], x[1]));
            }
        }

        private void Calculate()
        {
            ResultA = $"{Rounds.Sum(i => i.TotalScoreA)}";
            ResultB = $"{Rounds.Sum(i => i.TotalScoreB)}";
        }
    }
}
