using System;
using System.IO;

namespace MyTradeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var tradeStream = File.OpenRead("trades.txt"))
            {
                var tradeProcessor = new TradeProcessor();
                tradeProcessor.ProcessTrades(tradeStream);
            }
            Console.ReadKey();
        }
    }
}