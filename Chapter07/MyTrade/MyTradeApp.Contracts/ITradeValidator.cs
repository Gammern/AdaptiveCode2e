namespace MyTradeApp.Contracts
{
    public interface ITradeValidator
    {
        bool Validate(string[] tradeData);
    }
}
