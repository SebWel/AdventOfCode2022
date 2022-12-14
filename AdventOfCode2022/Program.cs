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
                //new Riddle01(), 
                //new Riddle02(),
                //new Riddle03(),
                //new Riddle04(),
                //new Riddle05(),
                //new Riddle06(),
                //new Riddle07(),
                //new Riddle08(),
                //new Riddle09(),
                //new Riddle10(),
                ////new Riddle11(),
                //new Riddle12(),
                //new Riddle13(),
                //new Riddle14(),
                new Riddle15(),
            };

            foreach (ISolvable riddle in solvables)
            {
                Console.WriteLine(riddle.GetType().Name + ": ");

                riddle.Solve();

                if (riddle.SolutionA != riddle.ResultA) throw new Exception();
                if (riddle.SolutionB != riddle.ResultB) throw new Exception();
                
                Console.WriteLine("A: " + riddle.ResultA);
                Console.WriteLine("B: " + riddle.ResultB);
                Console.WriteLine();
            }
        }
    }
}
