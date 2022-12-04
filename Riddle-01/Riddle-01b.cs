﻿namespace Riddle01
{
    using Common.Interfaces;

    public class Riddle01b : ISolvable
    {
        public string Result { get; set; }

        private FileStream File { get; set; }

        private List<int> Calories { get; set; }

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input01.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            using (StreamReader stream = new StreamReader(File))
            {
                Calories = new List<int>();
                int calorie = 0;

                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        calorie += int.Parse(line);
                    }
                    else
                    {
                        Calories.Add(calorie);
                        calorie = 0;
                    }
                }
            }
        }

        private void Calculate()
        {
            Calories = Calories.OrderByDescending(c => c).ToList();
            Result = $"{Calories[0] + Calories[1] + Calories[2]}";
        }
    }
}