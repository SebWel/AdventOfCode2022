namespace AdventOfCode2022
{
    using Interfaces;

    public class Riddle13 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "5806";

        public string SolutionB => "???";

        public List<DistressPair> Pairs { get; set; }

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
        }

        private void Parse()
        {
            int lineCount = 0;
            DistressPair pair = new();

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-13\\Input13.txt"))
            {
                switch (lineCount % 3 )
                {
                    case 0:
                        pair = new();
                        pair.Index = lineCount / 3 + 1;
                        pair.Left = new Packet(line);
                        break;
                    case 1:
                        pair.Right = new Packet(line);
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
            ResultB = $"{SolutionB}";
        }
    }
}