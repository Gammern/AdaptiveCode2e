using System;

namespace DecoratorPattern
{
    internal class AfterDecoratorComponent : IComponent
    {
        private IComponent decoratedComponent;

        public AfterDecoratorComponent(IComponent comp)
        {
            this.decoratedComponent = comp;
        }

        public void DoSomething()
        {
            decoratedComponent.DoSomething();
            Console.WriteLine("Flush and let the lid down");
        }
    }
}