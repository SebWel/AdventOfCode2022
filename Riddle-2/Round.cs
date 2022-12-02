namespace Riddle2
{
    using Enums;

    internal class Round
    {
        public Shape Shape { get; private set; }

        public Shape Response { get; private set; }

        public int ShapeScore => Calculate.ShapeScore(Response);

        public int OutcomeScore => Calculate.OutcomeScore(Shape, Response);

        public int TotalScore => ShapeScore + OutcomeScore;

        public Round (string shape, string reaction, Interpretation interpretation)
            : this(shape[0], reaction[0], interpretation)
        {
        }

        public Round(char shape, char reaction, Interpretation interpretation)
            : this ((Shape)shape, (Reaction)reaction, interpretation)
        {
        }

        public Round(Shape shape, Reaction reaction, Interpretation interpretation)
        {
            switch (interpretation)
            {
                case Interpretation.One:
                    Shape = shape;
                    Response = Calculate.Response(reaction);
                    break;
                case Interpretation.Two:
                    Shape = shape;
                    Response = Calculate.Response(shape, reaction);
                break;
                default: throw new NotImplementedException();
            }
        }
    }
}
