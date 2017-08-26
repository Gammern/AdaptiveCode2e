using System;

namespace SubtypeCovariance.Persitence
{
    using Model;

    public class UserRepository : IEntityRepository<User>
    {
        public User GetByID(Guid id) => new User(); 
    }
}
