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
        /// <param name="accountType">Fixed list of AccountType.Standard, AccountType.Bronze, AccountType.Silver, AccountType.Gold, AccountType.Platinum</param>
        /// <returns></returns>
        Account CreateAccount(AccountType accountType);

        /// <summary>
        /// Create account instance by using a string. No compile time checking of parameter :-(
        /// </summary>
        /// <param name="accountTypeName">"Standard", "Bronze", "Silver", "Gold", "Platinum" or some new type recently implemented</param>
        /// <returns></returns>
        Account CreateAccount(string accountTypeName);
    }
}
