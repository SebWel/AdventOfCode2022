namespace Riddle1
{
    using Common.Interfaces;

    public class Riddle1b : ISolvable
    {
        public string Result { get; set; }

        private FileStream File { get; set; }

        private int[] Calories { get; set; } = new int[1000];

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input1.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            using (StreamReader stream = new StreamReader(File))
            {
                int elf = 0;

                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        Calories[elf] += int.Parse(line);
                    }
                    else
                    {
                        elf++;
                    }
                }
            }
        }

        private void Calculate()
        {
            // Calories= Calories.OrderByDescending(c => c).ToArray();

            Array.Sort(Calories);
            Array.Reverse(Calories);

            Result = (Calories[0] + Calories[1] + Calories[2]).ToString();
        }
    }
}