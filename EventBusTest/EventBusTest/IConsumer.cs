using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusTest
{
    public interface IConsumer<T>
    {
        void HandlerEvent(T entity);
    }
}
