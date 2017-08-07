using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountLibrary.Tests
{
    using AccountLibrary.Domain;

    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void AddTransactionChangesBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
        }

        [TestMethod]
        public void AccountShouldHaveAnOpeningBalanceOfZero()
        {
            // Arrange
            var account = new Account();

            // Assert
            Assert.AreEqual(0m, account.Balance);
        }

        [TestMethod]
        public void Adding100TransactionChangesBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(100m);

            // Assert
            Assert.AreEqual(100m, account.Balance);
        }

        [TestMethod]
        public void AddingTwoTransactionsCreatesSummationBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(50m);
            account.AddTransaction(75);

            // Assert
            Assert.AreEqual(125m, account.Balance);
        }
    }
}
