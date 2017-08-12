namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var composite = new CompositeComponent("FirstCC");
            composite.AddComponent(new Leaf());
            composite.AddComponent(new SecondTypeOfLeaf());
            composite.AddComponent(new AThirdTypeOfLeaf());

            composite = new CompositeComponent("SecondCC")
                .AddComponent(new Leaf())
                .AddComponent(new SecondTypeOfLeaf())
                .AddComponent(new AThirdTypeOfLeaf())
                .AddComponent(composite);

            IComponent component = composite;
            component.Something();
        }
    }
}