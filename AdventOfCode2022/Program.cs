namespace AdventOfCode2022
{
    using Common.Interfaces;
    using Riddle1;
    using Riddle2;

    using System;

    public class Program
    {
        public static void Main()
        {
            var solvables = new List<ISolvable>
            {
                new Riddle1a(),
                new Riddle1b(),

                new Riddle2a(),
                new Riddle2b(),
            };

            foreach (ISolvable riddle in solvables)
            {
                Console.Write(riddle.GetType().Name + ": ");
                Console.WriteLine(riddle.Solve().Result);
                Console.WriteLine();
            }
        }
    }
}
