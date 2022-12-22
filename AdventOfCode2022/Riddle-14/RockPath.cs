namespace AdventOfCode2022
{
    public class PathInstruction
    {
        public Coordinate Start { get; set; }

        public Coordinate End { get; set; }

        public string ToString()
        {
            return $"{Start} -> {End}";
        }
    }
}
