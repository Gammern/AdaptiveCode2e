using System;

namespace CompositePattern
{
    public class Leaf : IComponent
    {
        public void Something(string indent)
        {
            Console.WriteLine($"{indent}{GetType().Name} 0x{GetHashCode():X}");
        }
    }
}
