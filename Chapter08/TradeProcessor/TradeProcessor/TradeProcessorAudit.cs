using System;

namespace TradeProcessorLib
{
    public sealed class TradeProcessorAudit : ITradeProcessor
    {
        public void ProcessTrades()
        {
            AuditTradeData();
            ListErrors();
        }

        private void ListErrors()
        {
            Console.WriteLine("TradeProcessorAudit: ListErrors()");
        }

        private void AuditTradeData()
        {
            Console.WriteLine("TradeProcessorAudit: AuditTradeData()");
        }
    }
}
