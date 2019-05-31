using EventBus.Entitys;

namespace EventBus.Event
{
    public class EntityAddEvent<T> where T : BaseEntity
    {
        public T Entity { get; }

        public  EntityAddEvent(T entity)
        {
            this.Entity = entity;
        }        
    }
}
