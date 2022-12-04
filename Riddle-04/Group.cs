namespace Riddle04
{
    internal class Group
    {
        public bool OverlappingFull => Assignments.First().OverlappingFull(Assignments.Last());

        public bool Overlapping => Assignments.First().Overlapping(Assignments.Last());

        private List<Assignment> Assignments { get; set; }

        public Group(params string[] assignments)
            : this (assignments.ToList())
        {
        }

        public Group(List<string> assignments)
        {
            Assignments = assignments.ConvertAll(ass => new Assignment(ass.Split('-')));
        }
    }
}
