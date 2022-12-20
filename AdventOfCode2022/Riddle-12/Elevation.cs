namespace AdventOfCode2022
{
    public class Elevation
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Heigh { get; set; }

        public IEnumerable<ElevationPath> FindEnd(Map map, ElevationPath path)
        {
            map.Write(path);

            if (map.End == this)
                return new List<ElevationPath> { path };

            return map.FindPossibilities(X, Y, Heigh, path).SelectMany(n => n.FindEnd(map, new ElevationPath() { Elevations = new List<Elevation>(path.Elevations) }.Add(n)));
        }

        public static bool Climbable(int currentHeigh, ElevationPath path, Elevation? possibility)
        {
            return possibility is not null 
                && possibility.Heigh - currentHeigh <= 1
                && !path.Elevations.Contains(possibility);
        }
    }
}
