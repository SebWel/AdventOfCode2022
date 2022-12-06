namespace Riddle06
{
    using Common.Interfaces;

    public class Riddle06a : ISolvable
    {
        public string Result { get; private set; }

        private FileStream File { get; set; }

        private int FirstMarkerAt { get; set; }

        public ISolvable Solve()
        {
            Load();
            Parse();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input06.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            Parse(4);
        }

        private void Parse(int markerSize)
        {
            var startOfPackageMarker = new int[markerSize];
            int cursor = 0;

            using (var stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    cursor++;

                    startOfPackageMarker[cursor % markerSize] = stream.Read();

                    if (cursor >= markerSize && startOfPackageMarker.Distinct().Count() == markerSize)
                    {
                        FirstMarkerAt = cursor;
                        return;
                    }
                }
            }
        }

        private void Calculate()
        {
            Result = $"{FirstMarkerAt}";
        }
    }
}
