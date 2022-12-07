namespace AdventOfCode2022
{
    using AdventOfCode2022.Interfaces;
    using System.IO;

    public class Riddle03 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "8139";

        public string SolutionB => "2668";

        private List<RucksackGroup> RucksackGroups = new List<RucksackGroup>();

        public ISolvable Solve()
        {
            Parse();
            Calculate();

            return this;
        }

        private void Parse()
        {
            RucksackGroups.Clear();
            var rucksacks = new Rucksack[3];
            int member = 0;
            
            foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "\\Riddle-03\\Input03.txt"))
            {
                var rucksack = new Rucksack(line);

                rucksacks[member] = rucksack;

                member++;
                if (member % 3 == 0)
                {
                    RucksackGroups.Add(new RucksackGroup(rucksacks[0], rucksacks[1], rucksacks[2]));
                    member = 0;
                }
            }
        }

        private void Calculate()
        {
            ResultA = $"{RucksackGroups.Sum(i => i.RucksackScore)}";
            ResultB = $"{RucksackGroups.Sum(i => i.Score)}";
        }
    }
}
