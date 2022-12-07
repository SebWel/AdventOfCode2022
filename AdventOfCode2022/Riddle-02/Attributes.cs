namespace AdventOfCode2022
{
    public static class AttributeHelper
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember($"{enumVal}");
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class ScoreAttribute : Attribute
    {
        public int Score;

        public ScoreAttribute(int score)
        {
            Score = score;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class ShapeAttribute : Attribute
    {
        public Shape Shape;

        public ShapeAttribute(Shape shape)
        {
            Shape = shape;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class OutcomeAttribute : Attribute
    {
        public Outcome Outcome;

        public OutcomeAttribute(Outcome outcome)
        {
            Outcome = outcome;
        }
    }
}
