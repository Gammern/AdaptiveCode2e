using System;

namespace StrategyPattern
{
    public interface ICornerCuttingStrategy
    {
        int Priority { get; }
        void Execute();
    }

    public class FlushCornerCuttingStrategy : ICornerCuttingStrategy
    {
        public int Priority { get; } = 2;

        public void Execute()
        {
            Console.WriteLine("Cutting flush");
        }
    }

    public class AngledCornerCuttingStrategy : ICornerCuttingStrategy
    {
        public int Priority { get; } = 1;

        public void Execute()
        {
            Console.WriteLine("Cutting an angle");
        }
    }
}
