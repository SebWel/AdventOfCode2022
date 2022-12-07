namespace AdventOfCode2022
{
    internal class Assignment
    {
        public int Start { get; private set; }

        public int End { get; private set; }

        public Assignment(params string[] range)
            : this(range[0], range[1])
        {
        }

        public Assignment(string start, string end)
            : this(int.Parse(start), int.Parse(end)) 
        {
        }

        public Assignment(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool Overlapping(Assignment a)
        {
            return Overlapping(this, a);
        }

        public bool OverlappingFull(Assignment a)
        {
            return OverlappingFull(this, a);
        }

        public static bool Overlapping(Assignment a, Assignment b)
        {
            if (a.Start >= b.Start && a.Start <= b.End
                || a.End >= b.Start && a.End <= b.End)
                return true;

            if (b.Start >= a.Start && b.Start <= a.End
                || b.End >= a.Start && b.End <= a.End)
                return true;

            return false;
        }

        public static bool OverlappingFull(Assignment a, Assignment b)
        {
            if (a.Start >= b.Start && a.Start <= b.End
                && a.End >= b.Start && a.End <= b.End)
                return true;

            if (b.Start >= a.Start && b.Start <= a.End
                && b.End >= a.Start && b.End <= a.End)
                return true;

            return false;
        }
    }
}
