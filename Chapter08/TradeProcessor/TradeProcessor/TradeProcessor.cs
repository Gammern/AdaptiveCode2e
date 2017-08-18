using System.Collections.Generic;

namespace TradeProcessorLib
{
    public class TradeProcessor
    {
        public static TradeProcessor Create()
        {
            return new TradeProcessorVersion2();
        }

        public virtual void ProcessTrades()
        {
            var lines = ReadTradeData();
            var trades = ParseTrades(lines);
            StoreTrades(trades);
        }

        private void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            System.Console.WriteLine("TradeProcessor: StoreTrades()");
        }

        private IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines)
        {
            System.Console.WriteLine("TradeProcessor: ParseTrades()");
            return new List<TradeRecord>();
        }

        private IEnumerable<string> ReadTradeData()
        {
            System.Console.WriteLine("TradeProcessor: ReadTradeData()");
            return new List<string>();
        }
    }
}
