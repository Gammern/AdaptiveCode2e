using AccountLibrary.Domain;
using AccountLibrary.Persistence;
using AccountLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AccountLibrary.Tests
{
    [TestClass]
    public class AccountServiceTests
    {
        private Mock<Account> mockAccount;
        private Mock<IAccountRepository> mockRepository;
        private AccountService sut; // System Under Test, could also be named target.
        private AccountServiceBuilder accountServiceBuider;

        [TestInitialize]
        public void Setup()
        {
            mockAccount = new Mock<Account>();
            mockRepository = new Mock<IAccountRepository>();
            sut = new AccountService(mockRepository.Object);
            accountServiceBuider = new AccountServiceBuilder();
        }

        // Using fake repository implemented in this testproject
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance_Fake()
        {
            // Arrange 
            var account = new Account();
            var fakeRepository = new FakeAccountRepository(account);
            var sut = new AccountService(fakeRepository);

            // act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
        }

        // Using Moq instead of implementing fake repository like fn above
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance_Moq()
        {
            // Arrange 
            var account = new Account();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account);
            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
        }

        // Using the Builder pattern insead of any of the above (mock, fake)
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance_Builder()
        {
            // Arrange 
            var target = accountServiceBuider
                .WithAccountCalled("Trading Account")
                .AddTransactionOfValue(200m)
                .Build();

            // Act
            target.AddTransactionToAccount("Trading Account", 200m);

            // Assert. Verify "Account a => a.AddTransaction(200)"
            accountServiceBuider.MockAccount.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAccountServiceWithNullAccountRepository()
        {
            // Act
            new AccountService(null);
        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // Arrange

            // Act
            sut.AddTransactionToAccount("Trading Account", 100m);

            // Assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceExceptions()
        {
            // Arrange
            // Next line requires virtual AddTransaction()
            mockAccount.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(mockAccount.Object);

            // Act
            try
            {
                sut.AddTransactionToAccount("Trading Account", 100m);
            }
            catch (ServiceException serviceException)
            {
                // Assert
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
            }
        }
    }
}
