using System;

namespace SubtypeCovariance.Persitence
{
    using Model;

    public interface IEntityRepository<TEntity> where TEntity : Entity
    {
        TEntity GetByID(Guid ID);
    }
}
