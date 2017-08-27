using System;

namespace SimpleCovariance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Supertypes gets populated by subtypes
            ICovariant<SuperType> covariant = new SubCovariant();
            Console.WriteLine(covariant.ToString());
            SuperType superType = covariant.MethodWhichReturnsT();
            Console.WriteLine(superType.ToString());
            Console.WriteLine($"Subtype.Method3() = {(superType as SubType).Method3()}");
        }
    }
}
