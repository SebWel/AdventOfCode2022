namespace Riddle03
{
    using Common.Interfaces;

    public class Riddle03b : ISolvable
    {
        public string Result { get; private set; }

        private FileStream File { get; set; }

        private List<Rucksack> Backpacks = new List<Rucksack>();

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input03.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            Backpacks.Clear();

            using (StreamReader stream = new StreamReader(File))
            {
                int member = 0;

                string[] group = new string[3];

                while (stream.Peek() >= 0)
                {
                    group[member] = stream.ReadLine();

                    member++;
                    if (member % 3 == 0)
                    {
                        Backpacks.Add(new Rucksack(group[0], group[1], group[2]));
                        member = 0;
                    }
                }
            }
        }

        private void Calculate()
        {
            Result = $"{Backpacks.Sum(i => i.Score)}";
        }
    }
}
