using System;

namespace CompositePattern
{
    class AThirdTypeOfLeaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine($"AThirdTypeOfLeaf 0x{GetHashCode():X}");
        }
    }
}
