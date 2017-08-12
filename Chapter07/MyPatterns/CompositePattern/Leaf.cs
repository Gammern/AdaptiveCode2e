using System;

namespace CompositePattern
{
    public class Leaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine($"Leaf 0x{GetHashCode():X}");
        }
    }
}
