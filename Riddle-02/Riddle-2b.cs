﻿namespace Riddle02
{
    using Common.Interfaces;
    using Riddle02.Enums;

    public class Riddle02b : ISolvable
    {
        public string Result { get; set; }

        private FileStream File { get; set; }

        private List<Round> Rounds = new List<Round>();

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();
                        
            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input02.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            Rounds.Clear();

            using (StreamReader stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();
                    string[] x = line.Split(' ');

                    Rounds.Add(new Round(x[0], x[1], Interpretation.Two));
                }
            }
        }

        private void Calculate()
        {
            Result = Rounds.Sum(i => i.TotalScore).ToString();
        }
    }
}