namespace AdventOfCode2022
{
    internal class RucksackGroup
    {
        public int Score => Duplicates.Sum(i => GetItemScore(i));

        private string Duplicates => FindDuplicates();

        public int RucksackScore => Rucksacks.Sum(i => i.Score);

        private List<Rucksack> Rucksacks = new List<Rucksack>();

        public RucksackGroup(params Rucksack[] rucksacks)
        {
            Rucksacks = rucksacks.ToList();
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

                if (Rucksacks.TrueForAll(item => item.Items.Contains(c)))
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
