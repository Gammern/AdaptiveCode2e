using System;

namespace MyAccounting.Model
{
    public class Account
    {
        public enum AccountType
        {
            Silver, Gold, Platinum
        }

        private readonly AccountType type;

        // Variable names should be traceable back to specifications
        private readonly int SilverTransactionCostPerPoint = 10;
        private readonly int GoldTransactionCostPerPoint = 5;
        private readonly int PlatiniumTransactionCostPerPoint = 2;

        private readonly int GoldBalanceCostPerPoint = 2000;
        private readonly int PlatiniumBalanceCostPerPoint = 1000;

        public decimal Balance { get; private set; }
        public int RewardPoints { get; private set; }

        public Account(AccountType type)
        {
            this.type = type;
        }

        public void AddTransaction(decimal amount)
        {
            RewardPoints += CalculateAwardPoints(amount);
            Balance += amount;
        }

        public int CalculateAwardPoints(decimal amount)
        {
            int points;
            switch (type)
            {
                case AccountType.Silver:
                    points = (int)decimal.Floor(amount / SilverTransactionCostPerPoint);
                    break;
                case AccountType.Gold:
                    points = (int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + (amount / GoldTransactionCostPerPoint));
                    break;
                case AccountType.Platinum:
                    points = (int)decimal.Floor((Balance / PlatiniumBalanceCostPerPoint) + (amount / PlatiniumTransactionCostPerPoint));
                    break;
                default:
                    points = 0;
                    break;
            }
            return Math.Max(points, 0);
        }
    }

    public class SilverAccount
    {
        private readonly int SilverTransactionCostPerPoint = 10;

        public int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor(amount / SilverTransactionCostPerPoint),0);
        }
    }

    public class GoldAccount
    {
        private readonly int GoldTransactionCostPerPoint = 5;
        private readonly int GoldBalanceCostPerPoint = 2000;
        public decimal Balance { get; private set; }

        public int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + (amount / GoldTransactionCostPerPoint)), 0);
        }
    }

    public class PlatinumAccount
    {
        private readonly int PlatiniumTransactionCostPerPoint = 2;
        private readonly int PlatiniumBalanceCostPerPoint = 1000;

        public decimal Balance { get; private set; }

        public int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor((Balance / PlatiniumBalanceCostPerPoint) + (amount / PlatiniumTransactionCostPerPoint)), 0);
        }
    }
}
