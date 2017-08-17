using System;

namespace LoggingDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
            var res = calculator.Add(2, 3);
            Console.WriteLine($"Main: result 2 + 3 is {res}");
            Console.WriteLine();

            // Now wrap the calculator and show debug messages for the same operation as above
            calculator = new CalculatorLoggingDecorator(calculator, Log);
            res = calculator.Add(2, 3);
            Console.WriteLine($"Main: result 2 + 3 is {res}");
        }

        static void Log(string message) =>  Console.WriteLine(message);
    }
}
