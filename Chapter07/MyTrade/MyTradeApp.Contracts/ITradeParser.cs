using System.Collections.Generic;

namespace MyTradeApp.Contracts
{
    public interface ITradeParser
    {
        IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
    }
}