using System.IO;

namespace DependencyInversion.Sensors
{
    public class Lazer : ISensor, IMovable, IMeasurable
    {
        private float x, y;

        public string GetName() => "lazer";

        public void Move(float x, float y)
        {
            this.x += x;
            this.y += y;
        }

        public float Measure()
        {
            return 0F;
        }

        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine($"Sensor {GetName()} measures {234567}nm");
        }
    }
}