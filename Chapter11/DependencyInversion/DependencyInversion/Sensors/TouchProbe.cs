namespace DependencyInversion.Sensors
{
    public class TouchProbe : Sensor
    {
        private float pitch, roll;
        private float height;

        public TouchProbe() : base("Touch probe")
        {
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

        public PoundsPerSquareInch GetPressure()
        {
            return new PoundsPerSquareInch(13.9F);
        }
    }

    public struct PoundsPerSquareInch
    {
        public PoundsPerSquareInch(float value)
        {
            Value = value;
        }

        public float Value { get; private set; }
    }
}