namespace Segregate.Publishing
{
    using Common;

    public class EntitySavedEvent<TEntity> : EventBase<TEntity>
    {
        public EntitySavedEvent(TEntity entity) : base(entity, "EntitySaved")
        {
        }
    }
}