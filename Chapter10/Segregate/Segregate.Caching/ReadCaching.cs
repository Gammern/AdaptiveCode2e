using Segregate.Common;
using System;
using System.Collections.Generic;

namespace Segregate.Caching
{
    public class ReadCaching<TEntity> : IRead<TEntity>
    {
        private Dictionary<Guid, TEntity> chachedEntities = new Dictionary<Guid, TEntity>();
        private IEnumerable<TEntity> allCachedEnteties;
        private readonly IRead<TEntity> decorated;

        public ReadCaching(IRead<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allCachedEnteties == null)
            {
                allCachedEnteties = decorated.ReadAll();
            }
            return allCachedEnteties;
        }

        public TEntity ReadOne(Guid identity)
        {
            var foundEntity = chachedEntities[identity];
            if (foundEntity == null)
            {
                foundEntity = decorated.ReadOne(identity);
                if (foundEntity != null)
                {
                    chachedEntities[identity] = foundEntity;
                }
            }
            return foundEntity;
        }
    }
}
