namespace AccountLibrary.Persistence
{
    using Domain;

    public interface IAccountRepository
    {
        Account GetByName(string accountName);
    }
}
