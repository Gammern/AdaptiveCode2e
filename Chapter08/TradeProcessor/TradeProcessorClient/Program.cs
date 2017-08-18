using TradeProcessorLib;

namespace TradeProcessorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeProcessor = TradeProcessorBase.Create(2);
            tradeProcessor.ProcessTrades();
        }
    }
}
