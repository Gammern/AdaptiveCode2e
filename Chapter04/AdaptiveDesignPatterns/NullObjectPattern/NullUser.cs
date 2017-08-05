using System;

namespace NullObjectPattern
{
    public class NullUser : IUser
    {
        public string Name { get; } = "Unknown";

        public void IncrementSessionTicket()
        {
            // do nothing
        }
    }
}