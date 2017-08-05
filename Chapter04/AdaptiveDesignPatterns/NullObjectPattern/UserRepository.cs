using System;
using System.Collections.Generic;
using System.Linq;

namespace NullObjectPattern
{
    public class UserRepository : IUserRepository
    {
        private ICollection<User> users;

        public UserRepository()
        {
            users = Enumerable.Range(1, 4).Select(_ => new User(Guid.NewGuid())).ToList();
        }

        public IUser GetByID(Guid userID)
        {
            return users.SingleOrDefault(u => u.ID == userID) as IUser ?? User.NullUser;
        }
    }
}
