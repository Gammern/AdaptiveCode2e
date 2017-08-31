using Segregate.Common;
using System;
using System.Collections.Generic;

namespace Segregate.Caching
{
    /// <summary>
    /// To many passthrough calls highlights the need for interface segregation
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CrudCaching<TEntity> : ICreateReadUpdate<TEntity>
    {
        private TEntity cachedEntity;
        private IEnumerable<TEntity> allChechedEntities;

        private readonly ICreateReadUpdate<TEntity> decorated;

        public CrudCaching(ICreateReadUpdate<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public void Create(TEntity entity)
        {
            decorated.Create(entity);  // redundant passthrough
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allChechedEntities == null)
            {
                allChechedEntities = decorated.ReadAll();
            }
            return allChechedEntities;
        }

        public TEntity ReadOne(Guid identity)
        {
            if(cachedEntity == null)
            {
                cachedEntity = decorated.ReadOne(identity);
            }
            return cachedEntity;
        }

        public void Update(TEntity entity)
        {
            decorated.Update(entity); // redundant passthrough
        }
    }
}
