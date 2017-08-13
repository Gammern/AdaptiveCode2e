using System;

namespace DecoratorPattern
{
    internal class CoffeeConcreteComponent : IComponent
    {
        public void DoSomething()
        {
            Console.Write("Coffee");
        }
    }
}