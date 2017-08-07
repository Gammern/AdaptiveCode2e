using AccountLibrary.Domain;
using AccountLibrary.Persistence;

namespace AccountLibrary.Tests
{
    public class FakeAccountRepository : IAccountRepository
    {
        private Account account;

        public FakeAccountRepository(Account account)
        {
            this.account = account;
        }

        public Account GetByName(string accountName) => account;
    }
}
