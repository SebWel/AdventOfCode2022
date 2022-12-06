namespace Riddle06
{
    using Common.Interfaces;

    public class Riddle06a : ISolvable
    {
        public string Result { get; private set; }

        private FileStream File { get; set; }

        private char[] StartOfPackageMarker { get; set; }

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
            int markerSize = 4;

            StartOfPackageMarker = new char[markerSize];
            FirstMarkerAt = 0;

            using (var stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    FirstMarkerAt++;

                    char x = (char)stream.Read();
                    int position = FirstMarkerAt % markerSize;
                    StartOfPackageMarker[position] = x;

                    var y = StartOfPackageMarker.Distinct();

                    if (FirstMarkerAt >= markerSize && y.Count() == markerSize)
                        return;
                }
            }
        }

        private void Calculate()
        {
            Result = $"{FirstMarkerAt}";
        }
    }
}
