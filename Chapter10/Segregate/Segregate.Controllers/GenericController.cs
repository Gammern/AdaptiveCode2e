using System;

namespace Segregate.Controllers
{
    using Common;

    public class GenericController<TEntity>
    {
        private readonly IRead<TEntity> reader;
        private readonly ISave<TEntity> saver;
        private readonly IDelete<TEntity> deleter;

        public GenericController(IRead<TEntity> entityReader, ISave<TEntity> entitySaver, IDelete<TEntity> entityDeleter)
        {
            this.reader = entityReader;
            this.saver = entitySaver;
            this.deleter = entityDeleter;
        }
        
        public void CreateEntity(TEntity entity)
        {
            saver.Save(entity);
        }

        public TEntity GetSingleEntity(Guid identity)
        {
            return reader.ReadOne(identity);
        }

        public void UpdateEntity(TEntity entity)
        {
            saver.Save(entity);
        }

        public void DeleteEntity(TEntity entity)
        {
            deleter.Delete(entity);
        }
    }
}
