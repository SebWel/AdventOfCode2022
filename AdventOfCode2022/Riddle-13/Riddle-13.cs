namespace AdventOfCode2022
{
    using Interfaces;

    public class Riddle13 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "5806";

        public string SolutionB => "23600";

        public List<Comparer> Pairs { get; set; }

        public List<Packet> Packets { get; set; }

        public ISolvable Solve()
        {
            Construct();
            Parse();
            Calculate();

            return this;
        }

        private void Construct()
        {
            Pairs = new();
            Packets = new();
        }

        private void Parse()
        {
            int lineCount = 0;
            Comparer pair = new();

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-13\\Input13.txt"))
            {
                switch (lineCount % 3 )
                {
                    case 0:
                        var left = new Packet(line);
                        Packets.Add(left);

                        pair = new();
                        pair.Index = lineCount / 3 + 1;
                        pair.Left = left;
                        break;
                    case 1:
                        var right = new Packet(line);
                        Packets.Add(right);

                        pair.Right = right;
                        Pairs.Add(pair);
                        break;
                    case 2:
                        break;
                    default: throw new NotImplementedException();
                }

                lineCount++;
            }
        }

        private void Calculate()
        {
            Pairs.ForEach(x => x.Validate());
            ResultA = $"{Pairs.Where(x => x.Valid == true).Sum(p => p.Index)}";

            var divider1 = new Packet("[[2]]");
            var divider2 = new Packet("[[6]]");
            Packets.Add(divider1);
            Packets.Add(divider2);
            Packets.Sort();
            ResultB = $"{(Packets.IndexOf(divider1) + 1) * (Packets.IndexOf(divider2) + 1)}";
        }
    }
}