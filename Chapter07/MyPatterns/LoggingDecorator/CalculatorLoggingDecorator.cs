using System;

namespace LoggingDecorator
{
    internal class CalculatorLoggingDecorator : ICalculator
    {
        private ICalculator calculator;
        private Action<string> Log;

        public CalculatorLoggingDecorator(ICalculator calculator, Action<string> logAction)
        {
            this.calculator = calculator;
            this.Log = logAction;
        }

        public int Add(int x, int y)
        {
            Log($"DEBUG: Adding {x} and {y}");
            int res = calculator.Add(x, y);
            Log($"DEBUG: Result of adding {x} and {y} is {res}");
            return res;
        }
    }
}