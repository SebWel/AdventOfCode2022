using System.Text;

namespace AdventOfCode2022
{
    public class Packet
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
