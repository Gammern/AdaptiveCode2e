namespace Segregate.Publishing
{
    public interface IEvent
    {
        string Name { get; }
    }

    public abstract class EventBase<TEntity> : IEvent
    {
        public EventBase(TEntity entity, string eventTypeName)
        {
            Entity = entity;
            Name = eventTypeName;
        }
        public TEntity Entity { get; private set; }
        public string Name { get; private set; } 
    }
}