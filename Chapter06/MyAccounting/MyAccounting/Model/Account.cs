using System;

namespace MyAccounting.Model
{
    public enum AccountType
    {
        Standard, Bronze, Silver, Gold, Platinum
    }

    public class Account
    {
        public decimal Balance { get; private set; }

        private readonly IRewardCard rewardCard;

        public Account(IRewardCard rewardCard)
        {
            this.rewardCard = rewardCard;
        }

        public void AddTransaction(decimal amount)
        {
            rewardCard.CalculateRewardPoints(amount, Balance);
            Balance += amount;
        }
    }

    internal class StandardAccount : IRewardCard
    {
        public int RewardPoints { get; } = 0;

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance) {}
    }

    internal class BronzeAccount : IRewardCard
    {
        private readonly int BronzeTransactionCostPerPoint = 20;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor(transactionAmount / BronzeTransactionCostPerPoint), 0);
        }
    }

    internal class SilverAccount : IRewardCard
    {
        private readonly int SilverTransactionCostPerPoint = 10;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor(transactionAmount / SilverTransactionCostPerPoint),0);
        }
    }

    internal class GoldAccount : IRewardCard
    {
        private readonly int GoldTransactionCostPerPoint = 5;
        private readonly int GoldBalanceCostPerPoint = 2000;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor((accountBalance / GoldBalanceCostPerPoint) + (transactionAmount / GoldTransactionCostPerPoint)), 0);
        }
    }

    internal class PlatinumAccount : IRewardCard
    {
        private readonly int PlatiniumTransactionCostPerPoint = 2;
        private readonly int PlatiniumBalanceCostPerPoint = 1000;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor((accountBalance / PlatiniumBalanceCostPerPoint) + (transactionAmount / PlatiniumTransactionCostPerPoint)), 0);
        }
    }
}
