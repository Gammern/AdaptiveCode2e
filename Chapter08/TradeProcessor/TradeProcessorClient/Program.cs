using TradeProcessorLib;

namespace TradeProcessorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeProcessorFactory = new TradeProcessorFactory();

            var tradeProcessor = tradeProcessorFactory.Create("TradeProcessorVersion2");
            tradeProcessor.ProcessTrades();
            System.Console.WriteLine();

            tradeProcessor = tradeProcessorFactory.Create("TradeProcessor");
            tradeProcessor.ProcessTrades();
            System.Console.WriteLine();

            tradeProcessor = tradeProcessorFactory.Create("TradeProcessorAudit");
            tradeProcessor.ProcessTrades();
            System.Console.WriteLine();
        }
    }
}
