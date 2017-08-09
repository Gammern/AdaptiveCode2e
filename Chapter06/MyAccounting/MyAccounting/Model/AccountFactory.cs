using System;

namespace MyAccounting.Model
{
    public class AccountFactory : IAccountFactory
    {
        public AccountBase CreateAccount(AccountType type)
        {
            AccountBase account = null;
            switch (type)
            {
                case AccountType.Bronze:
                    account = new BronzeAccount();
                    break;
                case AccountType.Silver:
                    account = new SilverAccount();
                    break;
                case AccountType.Gold:
                    account = new GoldAccount();
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount();
                    break;
            }
            return account;
        }

        public AccountBase CreateAccount(string accountType)
        {
            try
            {
                return (AccountBase)Activator.CreateInstance(Type.GetType($"MyAccounting.Model.{accountType}Account"));
            }
            catch (Exception ex)
            {
                throw new ModelException($"{accountType} is not valid name for an account type", ex);
            }
        }
    }
}
