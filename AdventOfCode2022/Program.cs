namespace AdventOfCode2022
{
    using Common.Interfaces;

    using Riddle01;
    using Riddle02;
    using Riddle03;
    using Riddle04;
    using Riddle05;
    using Riddle06;
    //using Riddle07;
    //using Riddle08;
    //using Riddle09;
    //using Riddle10;
    //using Riddle11;
    //using Riddle12;
    //using Riddle13;
    //using Riddle14;
    //using Riddle15;
    //using Riddle16;
    //using Riddle17;
    //using Riddle18;
    //using Riddle19;
    //using Riddle20;
    //using Riddle21;
    //using Riddle22;
    //using Riddle23;
    //using Riddle24;

    using System;

    public class Program
    {
        public static void Main()
        {
            var solvables = new List<ISolvable>
            {
                new Riddle01a(),
                new Riddle01b(),

                new Riddle02a(),
                new Riddle02b(),

                new Riddle03a(),
                new Riddle03b(),

                new Riddle04a(),
                new Riddle04b(),

                new Riddle05a(),
                new Riddle05b(),

                new Riddle06a(),
                new Riddle06b(),
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
