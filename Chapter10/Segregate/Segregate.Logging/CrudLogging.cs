using Segregate.Common;
using System;
using System.Collections.Generic;

namespace Segregate.Logging
{

    public class CrudLogging<TEnity> : ICreateReadUpdatedelete<TEnity>
    {
        private readonly ICreateReadUpdatedelete<TEnity> decoratedCrud;
        private readonly ILog log;

        public CrudLogging(ICreateReadUpdatedelete<TEnity> decoratedCrud, ILog log)
        {
            this.decoratedCrud = decoratedCrud;
            this.log = log;
        }

        public void Create(TEnity entity)
        {
            log.Info($"Creating entity of type {typeof(TEnity).Name}");
            decoratedCrud.Create(entity);
        }

        public void Delete(TEnity entity)
        {
            log.Info($"Deleting entity of type {typeof(TEnity).Name}");
            decoratedCrud.Delete(entity);
        }

        public IEnumerable<TEnity> ReadAll()
        {
            log.Info($"Reading all entities of type {typeof(TEnity).Name}");
            return decoratedCrud.ReadAll();
        }

        public TEnity ReadOne(Guid identity)
        {
            log.Info($"Reading entity of type {typeof(TEnity).Name} with identity {identity}");
            return decoratedCrud.ReadOne(identity);
        }

        public void Update(TEnity entity)
        {
            log.Info($"Updating entity of type {typeof(TEnity).Name}");
            decoratedCrud.Update(entity);
        }
    }
}
