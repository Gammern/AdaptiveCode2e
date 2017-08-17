using System;

namespace ProfilingDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent comp = new SlowComponent();
            Console.Write("Starting..");
            comp.Something();
            Console.WriteLine(" Done");

            comp = new ProfilingComponent(comp, Console.WriteLine);
            Console.Write("Starting..");
            comp.Something();
            Console.WriteLine(" Done");
        }
    }
}
