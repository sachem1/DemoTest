namespace EventBus
{
    public interface IConsumer<T>
    {
        void HandlerEvent(T entity);
    }
}
