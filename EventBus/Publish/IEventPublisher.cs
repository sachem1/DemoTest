namespace EventBus.Publish
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event);
        //void Publish<T>(EntityAddEvent<T> entityAddEvent) where T : BaseEntity;
    }
}
