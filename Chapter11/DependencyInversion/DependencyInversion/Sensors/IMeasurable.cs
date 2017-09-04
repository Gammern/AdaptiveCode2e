using System.IO;

namespace DependencyInversion.Sensors
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
