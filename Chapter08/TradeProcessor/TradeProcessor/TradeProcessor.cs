using System.Collections.Generic;

namespace TradeProcessorLib
{
    public class TradeProcessor : TradeProcessorBase
    {
        protected override void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            System.Console.WriteLine("TradeProcessor: StoreTrades()");
        }

        protected override IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines)
        {
            System.Console.WriteLine("TradeProcessor: ParseTrades()");
            return new List<TradeRecord>();
        }

        protected override IEnumerable<string> ReadTradeData()
        {
            System.Console.WriteLine("TradeProcessor: ReadTradeData()");
            return new List<string>();
        }
    }
}
