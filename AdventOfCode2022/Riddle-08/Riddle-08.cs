namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle08 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "1818";

        public string SolutionB => "368368";

        private Forestry Forestry { get; set; }

        public ISolvable Solve()
        {
            Parse();
            Calculate();

            return this;
        }

        private void Parse()
        {
            int x = 0;
            int y = 0;

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-08\\Input08.txt"))
            {
                if (Forestry == null) Forestry = new Forestry(line.Length);

                foreach (var heigh in line)
                {
                    Forestry.Add(x, y, (byte)char.GetNumericValue(heigh));
                    x++;
                }
                
                y++;
                x = 0;
            }
        }

        private void Calculate()
        {
            Forestry.CalculateVisibility();
            ResultA = $"{Forestry.AllTrees().Count(t => t.Visible)}";

            Forestry.CalculateScenicScore();
            ResultB = $"{Forestry.AllTrees().Max(t => t.ScenicScore)}";
        }
    }
}