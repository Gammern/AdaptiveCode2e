namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var composite = new CompositeComponent("First Composite Component");
            composite.AddComponent(new Leaf());
            composite.AddComponent(new Leaf());
            composite.AddComponent(new Leaf());

            // Fluent version since AddComponent return "this"
            composite = new CompositeComponent("Second Composite Component")
                .AddComponent(new Leaf())
                .AddComponent(new SecondTypeOfLeaf())
                .AddComponent(new AThirdTypeOfLeaf())
                .AddComponent(composite); // First will now become child of Second

            IComponent component = composite;
            component.Something(); // Will call Something() for all objects in the tree
        }
    }
}