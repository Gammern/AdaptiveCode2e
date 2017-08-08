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
                    points = (int)decimal.Floor(amount / 10);
                    break;
                case AccountType.Gold:
                    points = (int)decimal.Floor((Balance / 10000 * 5) + (amount / 5));
                    break;
                case AccountType.Platinum:
                    points = (int)decimal.Floor((Balance / 10000 * 10) + (amount / 2));
                    break;
                default:
                    points = 0;
                    break;
            }
            return Math.Max(points, 0);
        }
    }

}
