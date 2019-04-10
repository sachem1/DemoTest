using Autofac;
using EventBusTest.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EventBusTest.Publish
{
    public class EventPublisher : IEventPublisher
    {
       
        public EventPublisher()
        {
            var assemblys = System.AppDomain.CurrentDomain.GetAssemblies();
            //foreach (var assembly in assemblys)
            //{
            //    Consumers.AddRange(assembly.GetTypes().Where(x => x.IsSubclassOf( typeof(IConsumer<TEvent>))).ToList());
            //}
           
        }
        public virtual void Publish<TEvent>(TEvent tevent)
        {

            var scope = Program.Container;
            {
                var s = scope.Resolve<IConsumer<TEvent>>();
                s.HandlerEvent(tevent);
            }
            //foreach (var consumer in Consumers)
            //{
            //    consumer.HandlerEvent(tevent);
            //}
        }
    }
}
