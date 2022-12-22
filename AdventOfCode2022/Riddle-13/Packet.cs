using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdventOfCode2022
{
    public class Packet : IComparable<Packet>
    {
        public Queue<Packet> Childs { get; set; }

        public int? Value { get; set; }

        public Packet(string source)
        {
            int num = 0;
            var sb = new StringBuilder();

            if (source == string.Empty)
                return;

            if (int.TryParse(source, out int p))
            {
                Value = p;
                return;
            }

            for (int i = 0; i< source.Length; i++)
            {
                var c = source[i];

                num = c == '[' ? num + 1 : (c == ']' ? num - 1 : num);

                if (c == '[' && i == 0)
                {
                    sb.Clear();
                }
                else if (c == ']' && num == 0)
                {
                    if (Childs is null) Childs = new Queue<Packet>();

                    Childs.Enqueue(new Packet(i == source.Length - 1 ? sb.ToString() : "[" + sb.ToString() + "]"));
                    sb.Clear();
                }
                else if (c == ',' && num == 0)
                {
                    if (sb.Length > 0)
                    { 
                        if (Childs is null) Childs = new Queue<Packet>();
                        Childs.Enqueue(new Packet(sb.ToString()));
                        sb.Clear();
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }

            if (sb.Length > 0)
            {
                if (Childs is null) Childs = new Queue<Packet>();
                Childs.Enqueue(new Packet(sb.ToString()));
            }
        }

        public static bool? Validate(Packet left, Packet right)
        {
            if (left.Value is null && left.Childs is null && right.Value is null && right.Childs is null)
                return null;
            if (left.Value is null && left.Childs is null)
                return true;
            if (right.Value is null && right.Childs is null)
                return false;

            if (left.Value.HasValue && right.Value.HasValue)
            {
                if (left.Value.Value < right.Value.Value)
                    return true;

                if (left.Value.Value > right.Value.Value)
                    return false;

                return null;
            }

            if (left.Value.HasValue)
            {
                int temp = left.Value.Value;
                left.Value = null;

                left.Childs = new();
                left.Childs.Enqueue(new Packet($"{temp}"));
            }

            if (right.Value.HasValue)
            {
                int temp = right.Value.Value;
                right.Value = null;

                right.Childs = new();
                right.Childs.Enqueue(new Packet($"{temp}"));
            }

            if (left.Childs is not null && right.Childs is not null)
            {
                int i = -1;

                while (true)
                {
                    i++;

                    var leftHasNext = left.Childs.Count > i;
                    var rightHasNext = right.Childs.Count > i;

                    if (!leftHasNext && !rightHasNext)
                        return null;

                    if (!leftHasNext)
                        return true;

                    if (!rightHasNext)
                        return false;

                    var l = left.Childs.ElementAt(i);
                    var r = right.Childs.ElementAt(i);

                    var valid = Validate(l, r);

                    if (valid is not null)
                        return valid;
                }
            }

            return true;
        }

        public int CompareTo(Packet? other)
        {
            if (other == null) return 1;

            var valid = Validate(this, other);

            if (valid is null)
                return 0;

            if (valid.Value)
                return - 1;
            else
                return 1;
        }

        public string ToString()
        {
            if (Value.HasValue)
                return Value.Value.ToString();

            if (Childs is not null)
            {
                var sb = new StringBuilder();
                foreach(var child in Childs)
                {
                    sb.Append(child.ToString() + ", ");
                }

                return sb.ToString();
            }

            return "---";
        }
    }
}
