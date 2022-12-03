namespace Riddle3
{
    using Common.Interfaces;

    public class Riddle3a : ISolvable
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
            string pathSource = Directory.GetCurrentDirectory() + "\\Input3.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            Backpacks.Clear();

            using (StreamReader stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();

                    Backpacks.Add(new Rucksack(line));
                }
            }
        }

        private void Calculate()
        {
            Result = Backpacks.Sum(i => i.Score).ToString();
        }
    }
}
