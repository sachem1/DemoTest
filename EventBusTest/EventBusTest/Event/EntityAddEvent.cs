using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusTest
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
