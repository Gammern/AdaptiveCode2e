using System;

namespace SubtypeCovariance.Persitence
{
    using Model;

    public class UserRepository : EntityRepository
    {
        public override User GetByID(Guid id) => new User(); // Error. C# inheritance is not covariant
    }
}
