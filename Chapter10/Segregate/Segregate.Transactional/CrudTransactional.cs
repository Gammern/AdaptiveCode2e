﻿using Segregate.Common;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Segregate.Transactional
{
    public class CrudTransactional<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decoratedCrud;

        public CrudTransactional(ICreateReadUpdateDelete<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Create(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Create(entity);
                transaction.Complete();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Delete(entity);
                transaction.Complete();
            }
        }

        public IEnumerable<TEntity> ReadAll()
        {
            IEnumerable<TEntity> allEntities;
            using (var transaction = new TransactionScope())
            {
                allEntities = decoratedCrud.ReadAll();
                transaction.Complete();
            }
            return allEntities;
        }

        public TEntity ReadOne(Guid identity)
        {
            TEntity entity;
            using (var transaction = new TransactionScope())
            {
                entity = decoratedCrud.ReadOne(identity);
                transaction.Complete();
            }
            return entity;
        }

        public void Update(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Update(entity);
                transaction.Complete();
            }
        }
    }
}
