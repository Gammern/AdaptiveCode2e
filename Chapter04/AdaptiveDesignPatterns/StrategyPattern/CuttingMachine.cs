using System;

namespace StrategyPattern
{
    public class CuttingMachine
    {
        public void ProcessPart(FramePart partToProcess)
        {
            Console.WriteLine($"Processing part {partToProcess.Name}");
            foreach (var joiningPart in partToProcess.JoiningParts)
            {
                var cuttingStrategy = partToProcess.SelectCornerCuttingStrategy(joiningPart);
                Console.Write($"\tProcessing join with {joiningPart.Name}: ");
                cuttingStrategy.Execute();
            }
        }
    }
}
