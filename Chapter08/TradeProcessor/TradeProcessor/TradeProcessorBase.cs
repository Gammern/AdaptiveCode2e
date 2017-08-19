using System.Collections.Generic;

namespace TradeProcessorLib
{
    public abstract class TradeProcessorBase : ITradeProcessor
    {
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
