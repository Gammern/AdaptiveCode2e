using System;

namespace BranchingDecoratorPattern
{
    public class BoolPredicate : IPredicate
    {
        private readonly bool value;

        protected BoolPredicate(bool value)
        {
            this.value = value;
        }

        public bool Test() => value;
    }

    public class AlwaysFalsePredicate : BoolPredicate
    {
        public AlwaysFalsePredicate() : base(false)
        { }
    }

    public class AlwaysTruePredicate : BoolPredicate
    {
        public AlwaysTruePredicate() : base(true)
        { }
    }

    public class RandomPredicate : IPredicate
    {
        private Random rnd;

        public RandomPredicate()
        {
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public bool Test() => rnd.Next(1, 3) == 1;
    }
}
