using System;

namespace DecoratorPattern
{
    internal class SugarDecoratorComponent : IComponent
    {
        private readonly IComponent decoratedComponent;

        public SugarDecoratorComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public void DoSomething()
        {
            decoratedComponent.DoSomething();
            Console.Write(", sugar");
        }
    }
}