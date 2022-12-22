namespace AdventOfCode2022
{
    public class Comparer
    {
        public int Index { get; set; }

        public bool? Valid { get; set; }

        public Packet Left { get; set; }

        public Packet Right { get; set; }

        public void Validate()
        {
            Valid = Packet.Validate(Left, Right);
        }

        public string ToString()
        {
            return $"{Index}: {Valid}";
        }
    }
}
