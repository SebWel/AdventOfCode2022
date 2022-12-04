namespace Riddle03
{
    using Common.Interfaces;

    public class Riddle03a : ISolvable
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
                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();

                    if (line.Length % 2 != 0) throw new IndexOutOfRangeException();
                    if (line.Length != line.Length) throw new IndexOutOfRangeException();

                    string compartment1 = line.Substring(0, line.Length / 2);
                    string compartment2 = line.Substring(line.Length / 2);

                    Backpacks.Add(new Rucksack(compartment1, compartment2));
                }
            }
        }

        private void Calculate()
        {
            Result = Backpacks.Sum(i => i.Score).ToString();
        }
    }
}
