namespace AdventOfCode2022
{
    public class DistressPair
    {
        public int Index { get; set; }

        public bool? Valid { get; set; }

        public Packet Left { get; set; }

        public Packet Right { get; set; }

        public void Validate()
        {
            Valid = Validate(Left, Right);
        }

        public static bool Validate(Packet left, Packet right)
        {
            return true;
        }
    }
}
