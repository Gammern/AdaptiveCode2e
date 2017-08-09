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
                    account = new Account(new StandardAccount());
                    break;
                case AccountType.Bronze:
                    account = new Account(new BronzeAccount());
                    break;
                case AccountType.Silver:
                    account = new Account(new SilverAccount());
                    break;
                case AccountType.Gold:
                    account = new Account(new GoldAccount());
                    break;
                case AccountType.Platinum:
                    account = new Account(new PlatinumAccount());
                    break;
            }
            return account;
        }

        public Account CreateAccount(string accountType)
        {
            try
            {
                return new Account((IRewardCard)Activator.CreateInstance(Type.GetType($"MyAccounting.Model.{accountType}Account")));
            }
            catch (Exception ex)
            {
                throw new ModelException($"{accountType} is not valid name for an account type", ex);
            }
        }
    }
}
