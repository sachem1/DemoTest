using EventBus.Entitys;

namespace EventBus.Event
{
    public class EntityUpdateEvent<T> where T:BaseEntity
    {
        public T Entity { get; }

        public EntityUpdateEvent(T entity)
        {
            this.Entity = entity;
        }
    }
}
