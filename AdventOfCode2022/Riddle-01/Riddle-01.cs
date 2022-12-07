namespace AdventOfCode2022
{
    using AdventOfCode2022.Interfaces;
    using System.IO;

    public class Riddle01 : ISolvable
    {
        public string ResultA { get; set; }

        public string ResultB { get; set; }

        public string SolutionA => "69795";

        public string SolutionB => "208437";

        private List<int> Calories { get; set; }

        public ISolvable Solve()
        {
            Parse();
            Calculate();

            return this;
        }

        private void Parse()
        {
            Calories = new List<int>();
            int calorie = 0;

            foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "\\Riddle-01\\Input01.txt"))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    calorie += int.Parse(line);
                }
                else
                {
                    Calories.Add(calorie);
                    calorie = 0;
                }
            }
        }

        private void Calculate()
        {
            Calories = Calories.OrderByDescending(c => c).ToList();

            ResultA = $"{Calories[0]}";
            ResultB = $"{Calories[0] + Calories[1] + Calories[2]}";
        }
    }
}