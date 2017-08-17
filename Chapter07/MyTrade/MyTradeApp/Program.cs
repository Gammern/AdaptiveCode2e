using MyTradeApp.AdoNet;
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
                var logger = new ConsoleLogger();
                var tradeValidator = new SimpleTradeValidator(logger);
                var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
                var tradeMapper = new SimpleTradeMapper();
                var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
                var tradeStorage = new AdoNetTradeStorage(logger);

                var tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
                tradeProcessor.ProcessTrades();
            }

            Console.ReadKey();
        }
    }
}