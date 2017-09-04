namespace DependencyInversion.Sensors
{
    public class Lazer : ISensor, IMovable
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
    }
}