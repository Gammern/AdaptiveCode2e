using System.Collections.Generic;

namespace MyTradeApp.Contracts
{
    public interface ITradeStorage
    {
        void Persist(IEnumerable<TradeRecord> trades);
    }
}
