namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;
    using System.Linq;

    public class Riddle11 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "???";

        public string SolutionB => "???";

        public int WorryLevel { get; set; }

        public List<Monkey> Monkeys { get; set; }

        public ISolvable Solve()
        {
            Construct();
            Parse();
            Calculate();

            return this;
        }

        private void Construct()
        {
            Monkeys = new List<Monkey>();
            WorryLevel = 0;
        }

        private void Parse()
        {
            Monkey currentMonkey = new();

            foreach (var line in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Riddle-11\\Input11.txt"))
            {
                switch (line)
                {
                    case string s when s.StartsWith("Monkey "):
                        currentMonkey = new Monkey { Number = int.Parse(s.Split(' ')[1].TrimEnd(':')) };
                        Monkeys.Add(currentMonkey);
                        break;
                    case string s when s.StartsWith("  Starting items: "):
                        currentMonkey.StartingItems = s.Substring(18).Split(',').ToList().ConvertAll(i => int.Parse(i));
                        break;
                    case string s when s.StartsWith("  Operation: "):
                        currentMonkey.Operation = s.Substring(13);
                        break;
                    case string s when s.StartsWith("  Test: divisible by "):
                        currentMonkey.TestDivisible = int.Parse(s.Substring(21));
                        break;
                    case string s when s.StartsWith("    If true: throw to monkey "):
                        currentMonkey.True = int.Parse(s.Substring(29));
                        break;
                    case string s when s.StartsWith("    If false: throw to monkey "):
                        currentMonkey.False = int.Parse(s.Substring(30));
                        break;
                    case "":
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void Calculate()
        {
            ResultA = $"{SolutionA}";
            ResultB = $"{SolutionB}";
        }
    }
}