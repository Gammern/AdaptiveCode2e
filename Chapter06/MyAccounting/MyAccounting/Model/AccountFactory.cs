using System;

namespace MyAccounting.Model
{
    public class AccountFactory : IAccountFactory
    {
        public Account CreateAccount(AccountType accountType)
        {
            Account account = null;
            switch (accountType)
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

        public Account CreateAccount(string accountTypeName)
        {
            try
            {
                return new Account((IRewardCard)Activator.CreateInstance(Type.GetType($"MyAccounting.Model.{accountTypeName}RewardCard")));
            }
            catch (Exception ex)
            {
                throw new ModelException($"{accountTypeName} is not valid name for an account type", ex);
            }
        }
    }
}
