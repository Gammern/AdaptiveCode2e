namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var parts = new[]
            {
                new FramePart("Bottom", new FlushCornerCuttingStrategy()),
                new FramePart("Left Post", new AngledCornerCuttingStrategy()),
                new FramePart("Top", new AngledCornerCuttingStrategy()),
                new FramePart("Right Post", new AngledCornerCuttingStrategy()),
            };

            // join neighbouring parts, and last one to first (%)
            for (int i = 0; i < parts.Length; i++)
            {
                FramePart.Join(parts[i], parts[(i + 1) % parts.Length]);
            }

            // Send parts to cutting machine
            var machine = new CuttingMachine();
            foreach (var part in parts)
            {
                machine.ProcessPart(part);
            }
        }
    }
}