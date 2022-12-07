namespace AdventOfCode2022
{
    using Interfaces;
    using System.IO;

    public class Riddle06 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "1175";

        public string SolutionB => "3217";

        private int FirstMarkerAtA { get; set; }

        private int FirstMarkerAtB { get; set; }

        public ISolvable Solve()
        {
            Parse();
            Calculate();

            return this;
        }

        private void Parse()
        {
            FirstMarkerAtA = Parse(4);
            FirstMarkerAtB = Parse(14);
        }

        private int Parse(int markerSize)
        {
            var startOfPackageMarker = new int[markerSize];
            int cursor = 0;

            foreach (char element in File.ReadAllText(Directory.GetCurrentDirectory() + "\\Riddle-06\\Input06.txt"))
            {
                cursor++;

                startOfPackageMarker[cursor % markerSize] = element;

                if (cursor >= markerSize && startOfPackageMarker.Distinct().Count() == markerSize)
                {
                    return cursor;
                }
            }

            throw new Exception();
        }

        private void Calculate()
        {
            ResultA = $"{FirstMarkerAtA}";
            ResultB = $"{FirstMarkerAtB}";
        }
    }
}
