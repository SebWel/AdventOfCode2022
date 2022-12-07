namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle04 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "475";

        public string SolutionB => "825";

        private List<Group> Groups = new List<Group>();

        public ISolvable Solve()
        {
            Parse();
            Calculate();

            return this;
        }

        private void Parse()
        {
            Groups.Clear();

            foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "\\Riddle-04\\Input04.txt"))
            {
                Groups.Add(new Group(line.Split(',')));
            }
        }

        private void Calculate()
        {
            ResultA = $"{Groups.Count(group => group.OverlappingFull)}";
            ResultB = $"{Groups.Count(group => group.Overlapping)}";
        }
    }
}
