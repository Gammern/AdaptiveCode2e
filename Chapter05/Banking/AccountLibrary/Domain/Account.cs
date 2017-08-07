namespace AccountLibrary.Domain
{
    public class Account
    {
        public decimal Balance { get; private set; }

        public virtual void AddTransaction(decimal amount)
        {
            Balance += amount;
        }
    }
}
