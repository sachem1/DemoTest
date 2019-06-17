using System;
using EventBus.Entitys;
using EventBus.Event;
using EventBus.Publish;

namespace EventBus.Db
{
    public class DbContext
    {
        private IEventPublisher _eventPublisher;
        public void SaveOrder(Order order)
        {
            _eventPublisher = new EventPublisher();
            this.InsertChange();
            _eventPublisher.Publish(new EntityAddEvent<Order>(order));
        }

        public void InsertData<TEntity>(TEntity entity)where TEntity:BaseEntity
        {
            _eventPublisher = new EventPublisher();
            this.InsertChange();
            _eventPublisher.Publish(new EntityAddEvent<TEntity>(entity));
        }

        public void UpdateData<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _eventPublisher = new EventPublisher();
            this.Update();
            _eventPublisher.Publish(new EntityUpdateEvent<TEntity>(entity));
        }

        public void InsertChange() {
            Console.WriteLine("保存成功");
        }

        public void Update()
        {
            Console.WriteLine("更新数据成功！");
        }
    }
}
