using System.Collections.Generic;

namespace TradeProcessorLib
{
    public class TradeProcessorVersion2 : TradeProcessor
    {
        protected override IEnumerable<string> ReadTradeData()
        {
            System.Console.WriteLine("TradeProcessorVersion2: ReadTradeDataFromWebService()");
            return new List<string>();
        }
    }
}
