using EventBusTest.Entitys;
using EventBusTest.Event;
using EventBusTest.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusTest.Db
{
    public class DbContext
    {
        private IEventPublisher eventPublisher;
        public void SaveOrder(Order order)
        {
            eventPublisher = new EventPublisher();
            this.InsertChange();
            eventPublisher.Publish(new EntityAddEvent<Order>(order));
        }


        public void InsertData<TEntity>(TEntity entity)where TEntity:BaseEntity
        {
            eventPublisher = new EventPublisher();
            this.InsertChange();
            eventPublisher.Publish(new EntityAddEvent<TEntity>(entity));
        }

        public void UpdateData<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            eventPublisher = new EventPublisher();
            this.Update();
            eventPublisher.Publish(new EntityUpdateEvent<TEntity>(entity));
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
