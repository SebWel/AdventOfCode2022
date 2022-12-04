namespace Riddle3
{
    internal class Rucksack
    {
        public int Score => Duplicates.Sum(i => GetItemScore(i));

        private List<string> Compartments { get; set; }

        private string Duplicates { get; set; }

        public Rucksack(params string[] compartments)
        {
            Compartments = compartments.ToList();
            Duplicates = FindDuplicates();

            if (Duplicates.Length != 1) throw new NotImplementedException();
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
