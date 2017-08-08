using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAccounting.Model;

namespace MyAccounting.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void AccountShouldHaveInitialBalanceZero()
        {
            // Arrange 
            var sut = new Account(Account.AccountType.Silver);

            // Act

            // Assert
            Assert.AreEqual(0, sut.Balance);
        }

        [TestMethod]
        public void AccountTransaction100ShouldIncreaseBalance()
        {
            // Arrange 
            var sut = new Account(Account.AccountType.Silver);

            // Act
            sut.AddTransaction(100m);

            // Assert
            Assert.AreEqual(100m, sut.Balance);
        }

        [TestMethod]
        public void SilverAccountTransactionShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = new Account(Account.AccountType.Silver);

            // Act
            sut.AddTransaction(100m);

            Assert.AreEqual(10, sut.RewardPoints);
        }

        [TestMethod]
        public void GoldAccountTransactionShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = new Account(Account.AccountType.Gold);

            // Act
            sut.AddTransaction(100m);

            Assert.AreEqual(20, sut.RewardPoints);
        }

        [TestMethod]
        public void PlatiniumAccountTransactionShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = new Account(Account.AccountType.Platinum);

            // Act
            sut.AddTransaction(100m);

            Assert.AreEqual(50, sut.RewardPoints);
        }

        [TestMethod]
        public void PlatiniumAccountTransactionsShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = new Account(Account.AccountType.Platinum);

            // Act
            sut.AddTransaction(10000m);
            sut.AddTransaction(1000m);


            Assert.AreEqual(5510, sut.RewardPoints);
        }

    }
}
