using System;

namespace TradeProcessorLib
{
    public class TradeProcessorFactory
    {
        public virtual ITradeProcessor Create(string typeName)
        {
            return (ITradeProcessor)Activator.CreateInstance(Type.GetType($"TradeProcessorLib.{typeName}"));
        }
    }
}
