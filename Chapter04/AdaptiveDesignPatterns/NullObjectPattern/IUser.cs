namespace NullObjectPattern
{
    public interface IUser
    {
        string Name { get; }

        void IncrementSessionTicket();
    }
}