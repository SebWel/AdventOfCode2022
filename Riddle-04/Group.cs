namespace Riddle04
{
    internal class Group
    {
        public bool OverlappingFull
        { 
            get
            {
                var first = Assignments.First();
                var second = Assignments.Last();

                if (first.Start.Value >= second.Start.Value && first.Start.Value <= second.End.Value
                    && first.End.Value >= second.Start.Value && first.End.Value <= second.End.Value)
                    return true;

                if (second.Start.Value >= first.Start.Value && second.Start.Value <= first.End.Value
                    && second.End.Value >= first.Start.Value && second.End.Value <= first.End.Value)
                    return true;

                return false;
            } 
        }

        private List<Range> Assignments { get; set; }

        public Group(params string[] assignments)
        {
            Assignments = new List<Range>();

            foreach (var assignment in assignments)
            {
                int[] i = Array.ConvertAll(assignment.Split('-'), int.Parse);

                if (i.Count() != 2) throw new NotImplementedException();

                Assignments.Add(new Range(new Index(i[0]), new Index(i[1])));
            }
        }
    }
}
