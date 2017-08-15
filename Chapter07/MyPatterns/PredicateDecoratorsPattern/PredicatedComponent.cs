namespace PredicateDecoratorsPattern
{
    public class PredicatedComponent : IComponent
    {
        private readonly IComponent decoratedComponent;
        private IPredicate predicate;

        public PredicatedComponent(IComponent decoratedComponent, IPredicate predicate)
        {
            this.decoratedComponent = decoratedComponent;
            this.predicate = predicate;
        }

        public void Something()
        {
            if (predicate.Test())
            {
                decoratedComponent.Something();
            }
        }
    }
}
