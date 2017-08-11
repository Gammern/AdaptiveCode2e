using System;

namespace DecoratorPattern
{
    internal class DecoratorComponent : IComponent
    {
        private readonly IComponent decoratedComponent;

        public DecoratorComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public void DoSomething()
        {
            Console.WriteLine("Check bog roll availability");
            decoratedComponent.DoSomething();
        }
    }
}