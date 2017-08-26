using System;

namespace SubtypeCovariance.Persitence
{
    using Model;

    public class EntityRepository
    {
        public virtual Entity GetByID(Guid id) => new Entity();
    }
}
