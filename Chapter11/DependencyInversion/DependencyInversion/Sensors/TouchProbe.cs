using System.IO;

namespace DependencyInversion.Sensors
{
    public class TouchProbe : ISensor, IMovable, IRotatable, IHeightAdjustable, IMeasurable
    {
        private float pitch, roll;
        private float height;
        private float x, y;

        public string GetName() => "touchprobe";

        public void Move(float x, float y)
        {
            this.x += x;
            this.y += y;
        }

        public void Pitch(float pitch)
        {
            this.pitch += pitch;
        }

        public void Roll(float roll)
        {
            this.roll += roll;
        }

        public void Raise(float height)
        {
            this.height += height;
        }

        public void Lower(float height)
        {
            height -= height;
        }

        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine($"Sensor {GetName()} at {13.9F}psi");
        }
    }
}
