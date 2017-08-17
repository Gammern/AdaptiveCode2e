using MyTradeApp.Contracts;
using System;

namespace MyTradeApp
{
    public class ConsoleLogger : ILogger
    {
        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("INFO: ", message), args);
        }

        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }
    }
}
