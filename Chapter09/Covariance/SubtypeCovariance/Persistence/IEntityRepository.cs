using System;

namespace SubtypeCovariance.Persistence
{
    using Model;

    public interface IEntityRepository<out TEntity> where TEntity : Entity
    {
        TEntity GetByID(Guid ID);
    }
}
