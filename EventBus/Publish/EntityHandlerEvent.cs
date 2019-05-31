using System;
using EventBus.Entitys;
using EventBus.Event;

namespace EventBus.Handlers
{
    public class EntityHandlerEvent : IConsumer<EntityAddEvent<Order>>, IConsumer<EntityUpdateEvent<Order>>
    {
        public void HandlerEvent(EntityUpdateEvent<Order> entity)
        {
            Console.WriteLine("订单已更新!");
        }

        public void HandlerEvent(EntityAddEvent<Order> entity)
        {            
            Console.WriteLine("添加订单成功");
        }
    }
}