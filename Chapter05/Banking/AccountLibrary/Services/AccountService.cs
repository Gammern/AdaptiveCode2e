using System;

namespace AccountLibrary.Services
{
    using Domain;
    using Persistence;

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "A valid account repository must be slupplied.");
            }
            this.repository = repository;
        }

        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = repository.GetByName(uniqueAccountName);
            if (account != null)
            {
                try
                {
                    account.AddTransaction(transactionAmount);
                }
                catch (DomainException domainException)
                {
                    throw new ServiceException("Adding transaction to account failed", domainException);
                }
            }
        }
    }
}
