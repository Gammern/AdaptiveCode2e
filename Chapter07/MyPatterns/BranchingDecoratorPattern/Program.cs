using System;

namespace BranchingDecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obviously the predicate instance should not always return true or false. 
            // No point, unless you are doing internal testing of the implementation.
            var comp = new BranchedComponent(new TrueComponent(), new FalseComponent(), new AlwaysTruePredicate());
            comp.Something();

            comp = new BranchedComponent(new TrueComponent(), new FalseComponent(), new AlwaysFalsePredicate());
            comp.Something();

            comp = new BranchedComponent(new TrueComponent(), new FalseComponent(), new RandomPredicate());
            for (int i = 1; i < 10; i++)
            {
                Console.Write($"{i}: ");
                comp.Something();
            }
        }
    }
}
