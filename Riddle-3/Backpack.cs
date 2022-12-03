namespace Riddle3
{
    internal class Rucksack
    {
        public int Score => Duplicates.Sum(i => GetItemScore(i));

        private string Compartment1 { get; set; }
        
        private string Compartment2 { get; set; }

        private string Duplicates { get; set; }

        public Rucksack(string items)
            : this(items.Substring(0, items.Length / 2), items.Substring(items.Length / 2))
        {
            if (items.Length % 2 != 0) throw new IndexOutOfRangeException();
            if (Compartment1.Length != Compartment2.Length) throw new IndexOutOfRangeException();
        }

        public Rucksack(string compartment1, string compartment2)
        {
            Compartment1 = compartment1;
            Compartment2 = compartment2;

            Duplicates = FindDuplicates();
        }

        private string FindDuplicates()
        {
            return new string(FindDuplicates2().ToArray());
        }

        private IEnumerable<char> FindDuplicates2()
        {
            for (int i = 'A'; i <= 'z'; i++)
            {
                char c = (char)i;

                if (Compartment1.Contains(c) && Compartment2.Contains(c))
                    yield return c;
            }
        }

        private int GetItemScore(char item)
        {
            if (char.IsLower(item))
                return item - 96;
            if (char.IsUpper(item))
                return item - 38;

            throw new ArgumentOutOfRangeException();
        }
    }
}
