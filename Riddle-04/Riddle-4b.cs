namespace Riddle04
{
    using Common.Interfaces;

    public class Riddle04b : ISolvable
    {
        public string Result { get; private set; }

        private FileStream File { get; set; }

        private List<Group> Groups = new List<Group>();

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input04.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            Groups.Clear();

            using (StreamReader stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    Groups.Add(new Group(stream.ReadLine().Split(',')));
                }
            }
        }

        private void Calculate()
        {
            Result = Groups.Count(group => group.Overlapping).ToString();
        }
    }
}
