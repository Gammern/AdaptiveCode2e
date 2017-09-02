using System;
using System.Collections.Generic;

namespace Segregate.Common
{
    public interface IRead<TEntity>
    {
        TEntity ReadOne(Guid identity);
        IEnumerable<TEntity> ReadAll();
    }
}
