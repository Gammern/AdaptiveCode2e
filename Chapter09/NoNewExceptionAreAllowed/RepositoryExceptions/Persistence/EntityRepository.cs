using System;

namespace RepositoryExceptions.Persistence
{
    using Model;

    public class EntityRepositoryType<T, E> : IEntityRepository<T>
        where T : Entity, new()
        where E : Exception, new()
    {
        public T GetByID(Guid ID)
        {
            if (ID == Guid.Empty)
                throw new E();
            return new T();
        }
    }

    public class EntityRepository : EntityRepositoryType<Entity, EntityNotFoundException> { };
    public class UserRepository : EntityRepositoryType<User, UserNotFoundException> { };

    /*    
        public class EntityRepository : IEntityRepository<Entity>
        {
            public Entity GetByID(Guid ID)
            {
                if (ID == Guid.Empty)
                    throw new EntityNotFoundException();
                return new Entity();
            }
        }
        public class UserRepository : IEntityRepository<User>
        {
            public User GetByID(Guid ID)
            {
                if (ID == Guid.Empty)
                    throw new UserNotFoundException();
                return new User();
            }
        }
    */
}
