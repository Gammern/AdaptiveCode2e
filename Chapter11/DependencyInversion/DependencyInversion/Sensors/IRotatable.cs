namespace DependencyInversion.Sensors
{
    public interface IRotatable
    {
        void Pitch(float pitch);
        void Roll(float roll);
    }
}
