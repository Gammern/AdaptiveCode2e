using TradeProcessorLib;

namespace TradeProcessorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeProcessor = new TradeProcessor();
            tradeProcessor.ProcessTrades();
        }
    }
}
