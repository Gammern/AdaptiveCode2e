namespace AdapterPattern
{
    public sealed class Target
    {
        public void MethodB()
        {
            Program.Log(this);
        }
    }

    // Object Adapter Pattern (Wrapper)
    public class TargetAdapter : IExpectedInterface
    {
        private readonly Target target;

        public TargetAdapter(Target target)
        {
            this.target = target;
        }

        public void MethodA()
        {
            Program.Log(this);
            target.MethodB();
        }
    }
}
