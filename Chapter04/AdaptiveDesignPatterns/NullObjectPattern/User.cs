using System;

namespace NullObjectPattern
{
    class User : IUser
    {
        public static IUser NullUser { get; } = new NullUser();

        public User(Guid guid)
        {
            this.ID = guid;
        }

        public Guid ID { get; private set; }

        public void IncrementSessionTicket()
        {

        }

        public string Name { get; set; }
    }
}