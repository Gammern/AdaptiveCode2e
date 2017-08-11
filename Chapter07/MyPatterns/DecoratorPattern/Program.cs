namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent comp = new ConcreteComponent();
            comp = new DecoratorComponent(comp);
            comp = new AfterDecoratorComponent(comp);
            comp.DoSomething();
        }
    }
}