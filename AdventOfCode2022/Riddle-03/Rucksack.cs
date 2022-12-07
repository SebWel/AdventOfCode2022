namespace AdventOfCode2022
{
    internal class Rucksack
    {
        public int Score => Duplicates.Sum(i => GetItemScore(i));

        private string Duplicates => FindDuplicates();

        public string Items => string.Join("", Compartments);

        private List<string> Compartments { get; set; } = new List<string>();

        public Rucksack(string items)
        {
            Compartments.Add(items.Substring(0, items.Length / 2));
            Compartments.Add(items.Substring(items.Length / 2));
        }

        private string FindDuplicates()
        {
            return new string(FindDuplicatesAsIEnumerable().ToArray());
        }

        private IEnumerable<char> FindDuplicatesAsIEnumerable()
        {
            for (int i = 'A'; i <= 'z'; i++)
            {
                char c = (char)i;

                if (Compartments.TrueForAll(item => item.Contains(c)))
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
