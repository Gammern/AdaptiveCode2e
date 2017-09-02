namespace Segregate.Publishing
{
    public class EntityDeletedEvent<TEntity> : EventBase<TEntity>
    {
        public EntityDeletedEvent(TEntity entity) : base(entity, "EntityDeleted")
        {
        }

        public TEntity DeletedEntity => base.Entity;
    }
}