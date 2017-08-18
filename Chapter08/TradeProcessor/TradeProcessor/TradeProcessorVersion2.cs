using System.Collections.Generic;

namespace TradeProcessorLib
{
    public class TradeProcessorVersion2 : TradeProcessor
    {
        public override void ProcessTrades()
        {
            var lines = ReadTradeDataFromWebService();
            var trades = ParseTrades(lines);
            StoreTrades(trades);
        }

        private void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            System.Console.WriteLine("TradeProcessorVersion2: StoreTrades()");
        }

        private IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines)
        {
            System.Console.WriteLine("TradeProcessorVersion2: ParseTrades()");
            return new List<TradeRecord>();
        }

        private IEnumerable<string> ReadTradeDataFromWebService()
        {
            System.Console.WriteLine("TradeProcessorVersion2: ReadTradeDataFromWebService()");
            return new List<string>();
        }
    }
}
