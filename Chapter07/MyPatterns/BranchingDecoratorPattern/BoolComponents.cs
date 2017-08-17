using System;

namespace BranchingDecoratorPattern
{
    public class BoolComponent : IComponent
    {
        protected BoolComponent()
        { }

        public void Something() => Console.WriteLine($"{GetType().Name}.Something() executed.");
    }

    public class TrueComponent : BoolComponent
    { }

    public class FalseComponent : BoolComponent
    { }
}
