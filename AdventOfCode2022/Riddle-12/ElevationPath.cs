namespace AdventOfCode2022
{
    public class ElevationPath
    {
        public List<Elevation> Elevations { get; set; }

        public ElevationPath Add(Elevation elevation)
        {
            Elevations.Add(elevation);
            return this;
        }
    }
}
