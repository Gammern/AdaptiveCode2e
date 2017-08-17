using System.Collections.Generic;

namespace MyTradeApp.Contracts
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> GetTradeData();
    }
}