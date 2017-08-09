using System;

namespace MyAccounting.Model
{
    public class AccountFactory : IAccountFactory
    {
        public Account CreateAccount(AccountType type)
        {
            Account account = null;
            switch (type)
            {
                case AccountType.Standard:
                    account = new Account(new StandardRewardCard());
                    break;
                case AccountType.Bronze:
                    account = new Account(new BronzeRewardCard());
                    break;
                case AccountType.Silver:
                    account = new Account(new SilverRewardCard());
                    break;
                case AccountType.Gold:
                    account = new Account(new GoldRewardCard());
                    break;
                case AccountType.Platinum:
                    account = new Account(new PlatinumRewardCard());
                    break;
            }
            return account;
        }

        public Account CreateAccount(string accountType)
        {
            try
            {
                return new Account((IRewardCard)Activator.CreateInstance(Type.GetType($"MyAccounting.Model.{accountType}RewardCard")));
            }
            catch (Exception ex)
            {
                throw new ModelException($"{accountType} is not valid name for an account type", ex);
            }
        }
    }
}
