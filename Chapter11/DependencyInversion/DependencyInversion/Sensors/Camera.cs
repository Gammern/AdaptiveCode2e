namespace DependencyInversion.Sensors
{
    public class Camera : Sensor
    {
        private float zoomLevel;

        public Camera() : base("Camera")
        {
        }

        public void Zoom(float level) => zoomLevel = level;

        public object Capture()
        {
            return "This is a .NET core image";
        }
    }
}