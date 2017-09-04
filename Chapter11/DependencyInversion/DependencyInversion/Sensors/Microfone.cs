namespace DependencyInversion.Sensors
{
    public class Microfone : ISensor, IRotatable
    {
        private float pitch;
        private float roll;

        public string GetName() => "microfone";

        public SoundPressure Measure()
        {
            return new SoundPressure(85.3F);
        }

        public void Pitch(float pitch)
        {
            this.pitch += pitch;
        }

        public void Roll(float roll)
        {
            this.roll += roll;
        }
    }

    public class SoundPressure
    {
        public SoundPressure(float value)
        {
            this.Value = value;
        }

        public float Value { get; private set; }
    }
}
