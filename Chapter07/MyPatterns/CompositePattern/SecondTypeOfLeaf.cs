using System;

namespace CompositePattern
{
    public class SecondTypeOfLeaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine($"SecondTypeOfLeaf 0x{GetHashCode():X}");
        }
    }
}
