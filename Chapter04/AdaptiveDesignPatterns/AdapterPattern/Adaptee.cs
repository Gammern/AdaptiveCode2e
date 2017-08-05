namespace AdapterPattern
{
    public class Adaptee
    {
        public void MethodB()
        {
            Program.Log(this);
        }
    }

    // Class Adapter Pattern (inheritance)
    public class AdapteeAdapter : Adaptee, IExpectedInterface
    {
        public void MethodA()
        {
            Program.Log(this);
            MethodB();
        }
    }
}
