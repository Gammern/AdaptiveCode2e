namespace MyTradeApp.Contracts
{
    public interface ITradeMapper
    {
        TradeRecord Map(string[] fields);
    }
}
