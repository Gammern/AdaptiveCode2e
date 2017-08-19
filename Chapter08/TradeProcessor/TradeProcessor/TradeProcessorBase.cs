using System.Collections.Generic;

namespace TradeProcessorLib
{
    public abstract class TradeProcessorBase : ITradeProcessor
    {
        public static TradeProcessorBase Create(int version = 1)
        {
            return version == 2 ? (TradeProcessorBase)new TradeProcessorVersion2() : new TradeProcessor();
        }

        public virtual void ProcessTrades()
        {
            var lines = ReadTradeData();
            var trades = ParseTrades(lines);
            StoreTrades(trades);
        }

        protected abstract void StoreTrades(IEnumerable<TradeRecord> trades);

        protected abstract IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines);

        protected abstract IEnumerable<string> ReadTradeData();
    }
}
