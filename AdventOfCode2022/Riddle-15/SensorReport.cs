namespace AdventOfCode2022
{
    public class SensorReport
    {
        public Sensor Sensor { get; set; }

        public Beacon Beacon { get; set; }

        public int Distance { get; set; }

        public SensorReport(Sensor sensor, Beacon beacon)
        {
            Sensor = sensor;
            Beacon = beacon;

            Distance = Sensor.Distance(Beacon);
        }
    }
}
