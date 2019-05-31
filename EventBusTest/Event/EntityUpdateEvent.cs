using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusTest.Event
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
