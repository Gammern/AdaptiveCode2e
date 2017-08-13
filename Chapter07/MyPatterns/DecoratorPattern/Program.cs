namespace DecoratorPattern
{
    class Program
    {
        /// <summary>
        /// Decorate/wrap coffee with milk and sugar
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IComponent comp = new CoffeeConcreteComponent();
            comp.DoSomething();
            System.Console.WriteLine();

            // Add milk to the coffee
            comp = new MilkDecoratorComponent(comp);
            comp.DoSomething();
            System.Console.WriteLine();

            // Add sugar 
            comp = new SugarDecoratorComponent(comp);
            comp.DoSomething();
            System.Console.WriteLine();
        }
    }
}