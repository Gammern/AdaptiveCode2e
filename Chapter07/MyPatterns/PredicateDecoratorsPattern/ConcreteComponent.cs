using System;

namespace PredicateDecoratorsPattern
{
    public class ConcreteComponent : IComponent
    {
        public void Something()
        {
            Console.WriteLine($"{GetType().Name} executed");
        }
    }
}
