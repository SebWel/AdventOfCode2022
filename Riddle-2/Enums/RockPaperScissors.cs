namespace Riddle2.Enums
{
    internal enum Shape
    {
        [Score(1)]
        Rock = 'A',
        
        [Score(2)]
        Paper = 'B',

        [Score(3)]
        Scissors = 'C'
    }

    internal enum Reaction
    {
        [Shape(Shape.Rock)]
        [Outcome(Outcome.Loss)]
        X = 'X',

        [Shape(Shape.Paper)]
        [Outcome(Outcome.Draw)]
        Y = 'Y',

        [Shape(Shape.Scissors)]
        [Outcome(Outcome.Win)]
        Z = 'Z'
    }

    internal enum Outcome
    {
        [Score(0)]
        Loss,

        [Score(3)]
        Draw,
        
        [Score(6)]
        Win
    }

    internal enum Interpretation
    {
        One,
        Two
    }
}
