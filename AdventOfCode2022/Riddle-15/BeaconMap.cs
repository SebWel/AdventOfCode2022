namespace AdventOfCode2022
{
    public class BeaconMap
    {
        public List<SensorReport> Reports { get; set; }

        public BeaconMap()
        {
            Reports = new();
        }

        public void Add(SensorReport report)
        {
            Reports.Add(report);
        }

        public int Calculate(int line)
        {
            List<int> revealed = new();

            foreach(var report in Reports)
            {
                int distanceToLine = report.Sensor.Distance(new Coordinate(report.Sensor.X, line));

                if (distanceToLine > report.Distance)
                    continue;

                int rest = report.Distance - distanceToLine;

                int maxLeft = report.Sensor.X - rest;
                int maxRight = report.Sensor.X + rest;

                revealed.AddRange(Enumerable.Range(maxLeft, maxRight - maxLeft + 1));
            }

            revealed = revealed.Distinct().ToList();
            revealed.Sort();
            
            foreach (var report in Reports)
            {
                if (report.Beacon.Y == line)
                    revealed.Remove(report.Beacon.X);
            }           

            return revealed.Count;
        }
    }
}
