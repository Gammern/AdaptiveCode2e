namespace DependencyInversion.Sensors
{
    public class Lazer : Sensor
    {
        public Lazer() : base("Lazer")
        {
        }

        public float Measure()
        {
            return 0F;
        }
    }
}