using System;

namespace SubtypeCovariance.Persitence
{
    using Model;

    public class EntityRepository : IEntityRepository<Entity>
    {
        public virtual Entity GetByID(Guid id) => new Entity();
    }
}
