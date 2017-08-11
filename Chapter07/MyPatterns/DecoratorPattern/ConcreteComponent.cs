using System;

namespace DecoratorPattern
{
    internal class ConcreteComponent : IComponent
    {
        public void DoSomething()
        {
            Console.WriteLine("Having a dump");
        }
    }
}