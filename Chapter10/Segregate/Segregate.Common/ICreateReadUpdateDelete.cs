using System;
using System.Collections.Generic;

namespace Segregate.Common
{
    public interface ICreateReadUpdatedelete<TEntity>
    {
        void Create(TEntity entity);
        TEntity ReadOne(Guid identity);
        IEnumerable<TEntity> ReadAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
