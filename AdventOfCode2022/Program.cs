namespace AdventOfCode2022
{
    using AdventOfCode2022.Interfaces;

    using System;

    public class Program
    {
        public static void Main()
        {
            var solvables = new List<ISolvable>
            {
                new Riddle01(), 
                new Riddle02(),
                new Riddle03(),
                new Riddle04(),
                new Riddle05(),
                new Riddle06(),
                new Riddle07(),
            };

            foreach (ISolvable riddle in solvables)
            {
                riddle.Solve();

                if (riddle.SolutionA != riddle.ResultA) throw new Exception();
                if (riddle.SolutionB != riddle.ResultB) throw new Exception();

                Console.WriteLine(riddle.GetType().Name + ": ");
                Console.WriteLine("A: " + riddle.ResultA);
                Console.WriteLine("B: " + riddle.ResultB);
                Console.WriteLine();
            }
        }
    }
}
