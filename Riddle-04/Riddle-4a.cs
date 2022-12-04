namespace Riddle04
{
    using Common.Interfaces;

    public class Riddle04a : ISolvable
    {
        public string Result { get; private set; }

        private FileStream File { get; set; }

        //private List<Rucksack> Backpacks = new List<Rucksack>();

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input04.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            //Backpacks.Clear();

            using (StreamReader stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();

                    //Backpacks.Add(new Rucksack(compartment1, compartment2));
                }
            }
        }

        private void Calculate()
        {
            Result = string.Empty;
        }
    }
}
