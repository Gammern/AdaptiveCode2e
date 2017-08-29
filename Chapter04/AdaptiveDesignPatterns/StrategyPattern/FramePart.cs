using System.Collections.Generic;

namespace StrategyPattern
{
    public class FramePart
    {
        public static void Join(FramePart part1, FramePart part2)
        {
            part1.JoiningParts.Add(part2);
            part2.JoiningParts.Add(part1);
        }

        public ICornerCuttingStrategy SelectCornerCuttingStrategy(FramePart otherPart) =>
            this.CuttingStrategy.Priority > otherPart.CuttingStrategy.Priority ? this.CuttingStrategy : otherPart.CuttingStrategy;

        public FramePart(string name, ICornerCuttingStrategy cuttingStrategy)
        {
            this.Name = name; 
            this.CuttingStrategy = cuttingStrategy;
            this.JoiningParts = new HashSet<FramePart>();
        }

        public ICornerCuttingStrategy CuttingStrategy { get; }
        public string Name { get; }
        public HashSet<FramePart> JoiningParts { get; }
    }
}
