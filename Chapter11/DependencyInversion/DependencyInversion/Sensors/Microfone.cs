using System.IO;

namespace DependencyInversion.Sensors
{
    public class Microfone : ISensor, IRotatable, IMeasurable
    {
        private float pitch;
        private float roll;

        public string GetName() => "microfone";

        public void Pitch(float pitch)
        {
            this.pitch += pitch;
        }

        public void Roll(float roll)
        {
            this.roll += roll;
        }

        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine($"Sensor {GetName()} at {85.3F}dB");
        }
    }
}
