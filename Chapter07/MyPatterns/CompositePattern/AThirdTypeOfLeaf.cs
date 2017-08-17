using System;

namespace CompositePattern
{
    class AThirdTypeOfLeaf : IComponent
    {
        public void Something(string indent)
        {
            Console.WriteLine($"{indent}{GetType().Name} 0x{GetHashCode():X}");
        }
    }
}
