namespace AdventOfCode2022
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Coordinate(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public bool IsTouching(Coordinate other)
        {
            return IsTouching(X, other.X) && IsTouching(Y, other.Y);
        }

        private bool IsTouching (int a, int b)
        {
            return Math.Abs(a - b) < 2;
        }

        public override bool Equals(object obj) => Equals(obj as Coordinate);

        public bool Equals(Coordinate? other)
        {
            if (other is null)
                return false;

            if (X == other.X && Y == other.Y)
                return true;

            return false;
        }

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(Coordinate lhs, Coordinate rhs)
        {
            if (lhs is null && rhs is null)
                return true;

            if (lhs is null || rhs is null)
                return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinate lhs, Coordinate rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{X} | {Y}";
        }
    }
}
