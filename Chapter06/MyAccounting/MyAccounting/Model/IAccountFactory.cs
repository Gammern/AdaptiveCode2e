using System;
using System.Collections.Generic;
using System.Text;

namespace MyAccounting.Model
{
    public interface IAccountFactory
    {
        /// <summary>
        /// Create an Account by using enum AccountType
        /// </summary>
        /// <param name="type">Fixed list of AccountType.Bronze, AccountType.Silver, AccountType.Gold, AccountType.Platinum</param>
        /// <returns></returns>
        AccountBase CreateAccount(AccountType type);

        /// <summary>
        /// Create account instance by using a string
        /// </summary>
        /// <param name="accountType">"Bronze", "Silver", "Gold", "Platinum" or some new type recently implemented</param>
        /// <returns></returns>
        AccountBase CreateAccount(string accountType);
    }
}
