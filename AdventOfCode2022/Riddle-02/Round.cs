namespace AdventOfCode2022
{
    internal class Round
    {
        public Shape Shape { get; private set; }

        public Shape ResponseA { get; private set; }

        public Shape ResponseB { get; private set; }

        public int TotalScoreA => Calculate.TotalScore(Shape, ResponseA);

        public int TotalScoreB => Calculate.TotalScore(Shape, ResponseB);

        public Round (string shape, string reaction)
            : this(shape[0], reaction[0])
        {
        }

        public Round(char shape, char reaction)
            : this ((Shape)shape, (Reaction)reaction)
        {
        }

        public Round(Shape shape, Reaction reaction)
        {
            Shape = shape;
            ResponseA = Calculate.Response(reaction);
            ResponseB = Calculate.Response(shape, reaction);
        }
    }
}
