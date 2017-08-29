namespace AdapterPattern
{
    public class Adaptee
    {
        public void MethodB()
        {
            Program.Log(nameof(Adaptee));
        }
    }

    // Class Adapter Pattern (inheritance)
    public class AdapteeAdapter : Adaptee, IExpectedInterface
    {
        public void MethodA()
        {
            Program.Log(nameof(AdapteeAdapter));
            MethodB();
        }
    }
}
