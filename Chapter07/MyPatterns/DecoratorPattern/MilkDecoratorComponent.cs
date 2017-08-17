using System;

namespace DecoratorPattern
{
    internal class MilkDecoratorComponent : IComponent
    {
        private readonly IComponent decoratedComponent;

        public MilkDecoratorComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public void DoSomething()
        {
            decoratedComponent.DoSomething();
            Console.Write(", milk");
        }
    }
}