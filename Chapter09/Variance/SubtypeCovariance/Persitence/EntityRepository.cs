using System;

namespace SubtypeCovariance.Persitence
{
    using Model;

    public class EntityRepositoryType<T> : IEntityRepository<T> where T : Entity, new()
    {
        public T GetByID(Guid ID) => new T();
    }

    public class EntityRepository : EntityRepositoryType<Entity> { }
    public class UserRepository : EntityRepositoryType<User> { }
}
