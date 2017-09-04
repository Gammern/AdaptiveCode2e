namespace DependencyInversion.Sensors
{
    public interface IHeightAdjustable
    {
        void Raise(float height);
        void Lower(float height);
    }
}
