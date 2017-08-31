namespace Segregate.Publishing
{
    public class EntitySavedEvent<TEntity> : EventBase<TEntity>
    {
        public EntitySavedEvent(TEntity entity) : base(entity, "EntitySaved")
        {
        }
    }
}