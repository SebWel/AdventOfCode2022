using Riddle02.Enums;

namespace Riddle02
{
    internal static class Calculate
    {
        internal static int ShapeScore(Shape response)
        {
            return AttributeHelper.GetAttributeOfType<ScoreAttribute>(response).Score;
        }

        internal static int OutcomeScore(Shape shape, Shape response)
        {
            var outcome = OutcomeType(shape, response);
            return AttributeHelper.GetAttributeOfType<ScoreAttribute>(outcome).Score;
        }

        internal static Outcome OutcomeType(Shape shape, Shape response)
        {
            switch (shape, response)
            {
                case (Shape.Rock, Shape.Rock):
                case (Shape.Paper, Shape.Paper):
                case (Shape.Scissors, Shape.Scissors):
                    return Outcome.Draw;

                case (Shape.Rock, Shape.Scissors):
                case (Shape.Paper, Shape.Rock):
                case (Shape.Scissors, Shape.Paper):
                    return Outcome.Loss;

                case (Shape.Rock, Shape.Paper):
                case (Shape.Paper, Shape.Scissors):
                case (Shape.Scissors, Shape.Rock):
                    return Outcome.Win;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Calculates the Response out of the Reaction with Interpreatation One
        /// </summary>
        internal static Shape Response(Reaction reaction)
        {
            return AttributeHelper.GetAttributeOfType<ShapeAttribute>(reaction).Shape;
        }

        /// <summary>
        /// Calculates the Response out of the Reaction with Interpreatation Two
        /// </summary>
        internal static Shape Response(Shape shape, Reaction reaction)
        {
            var outcome = AttributeHelper.GetAttributeOfType<OutcomeAttribute>(reaction).Outcome;

            switch (shape, outcome)
            {
                case (Shape.Rock, Outcome.Draw):
                case (Shape.Paper, Outcome.Loss):
                case (Shape.Scissors, Outcome.Win):
                    return Shape.Rock;

                case (Shape.Rock, Outcome.Win):
                case (Shape.Paper, Outcome.Draw):
                case (Shape.Scissors, Outcome.Loss):
                    return Shape.Paper;

                case (Shape.Rock, Outcome.Loss):
                case (Shape.Paper, Outcome.Win):
                case (Shape.Scissors, Outcome.Draw):
                    return Shape.Scissors;

                default: throw new NotImplementedException();
            }
        }
    }
}
