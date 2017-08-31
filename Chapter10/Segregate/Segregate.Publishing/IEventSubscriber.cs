namespace Segregate.Publishing
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
