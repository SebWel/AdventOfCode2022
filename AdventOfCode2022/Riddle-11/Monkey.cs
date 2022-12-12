namespace AdventOfCode2022
{
    public class Monkey
    {
        public int Number { get; set; }

        public List<int> StartingItems { get; set; }

        public string Operation { get; set; } //+13 | + 3 | * old 

        public int TestDivisible { get; set; }

        public int True { get; set; }

        public int False { get; set; }
    }
}
