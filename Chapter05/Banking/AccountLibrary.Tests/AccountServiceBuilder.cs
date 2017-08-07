using AccountLibrary.Domain;
using AccountLibrary.Persistence;
using AccountLibrary.Services;
using Moq;

namespace AccountLibrary.Tests
{
    public class AccountServiceBuilder
    {
        private readonly AccountService accountService;
        private readonly Mock<IAccountRepository> mockAccountRepo;
        public Mock<Account> MockAccount { get; private set; }

        public AccountServiceBuilder()
        {
            mockAccountRepo = new Mock<IAccountRepository>();
            accountService = new AccountService(mockAccountRepo.Object);
        }

        public AccountServiceBuilder WithAccountCalled(string accountName)
        {
            MockAccount = new Mock<Account>();
            mockAccountRepo.Setup(r => r.GetByName(accountName)).Returns(MockAccount.Object);
            return this;
        }

        public AccountServiceBuilder AddTransactionOfValue(decimal transactionValue)
        {
            MockAccount.Setup(a => a.AddTransaction(transactionValue)).Verifiable();
            return this;
        }

        public AccountService Build()
        {
            return accountService;
        }
    }
}
