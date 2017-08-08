using System;

namespace MyAccounting.Model
{
    public enum AccountType
    {
        Silver, Gold, Platinum
    }

    public abstract class AccountBase // "Base" suffix indicate abstract class
    {
        public decimal Balance { get; private set; }
        public int RewardPoints { get; private set; }

        public void AddTransaction(decimal amount)
        {
            RewardPoints += CalculateRewardPoints(amount);
            Balance += amount;
        }

        public abstract int CalculateRewardPoints(decimal amount);
    }

    public class SilverAccount : AccountBase
    {
        private readonly int SilverTransactionCostPerPoint = 10;

        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor(amount / SilverTransactionCostPerPoint),0);
        }
    }

    public class GoldAccount : AccountBase
    {
        private readonly int GoldTransactionCostPerPoint = 5;
        private readonly int GoldBalanceCostPerPoint = 2000;

        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + (amount / GoldTransactionCostPerPoint)), 0);
        }
    }

    public class PlatinumAccount : AccountBase
    {
        private readonly int PlatiniumTransactionCostPerPoint = 2;
        private readonly int PlatiniumBalanceCostPerPoint = 1000;


        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor((Balance / PlatiniumBalanceCostPerPoint) + (amount / PlatiniumTransactionCostPerPoint)), 0);
        }
    }
}
