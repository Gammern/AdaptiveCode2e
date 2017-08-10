namespace MyAccounting.Model
{
    public enum AccountType
    {
        Standard, Bronze, Silver, Gold, Platinum
    }

    public class Account
    {
        public decimal Balance { get; private set; }

        private readonly IRewardCard rewardCard;

        public Account(IRewardCard rewardCard)
        {
            this.rewardCard = rewardCard;
        }

        public void AddTransaction(decimal amount)
        {
            rewardCard.CalculateRewardPoints(amount, Balance);
            Balance += amount;
        }
    }
}
