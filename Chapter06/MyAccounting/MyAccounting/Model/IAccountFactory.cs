using System;
using System.Collections.Generic;
using System.Text;

namespace MyAccounting.Model
{
    /// <summary>
    /// Factory to create Account instance. NOTE! We have two factory methods here. Should only have one.
    /// </summary>
    public interface IAccountFactory
    {
        /// <summary>
        /// Create an Account by using enum AccountType. Bonus: Compile time checking of parameter.
        /// </summary>
        /// <param name="type">Fixed list of AccountType.Bronze, AccountType.Silver, AccountType.Gold, AccountType.Platinum</param>
        /// <returns></returns>
        Account CreateAccount(AccountType type);

        /// <summary>
        /// Create account instance by using a string. No compile time checking of parameter :-(
        /// </summary>
        /// <param name="accountType">"Bronze", "Silver", "Gold", "Platinum" or some new type recently implemented</param>
        /// <returns></returns>
        Account CreateAccount(string accountType);
    }
}
