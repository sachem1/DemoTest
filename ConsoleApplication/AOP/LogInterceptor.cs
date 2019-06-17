using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace ConsoleApplication.AOP
{
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}方法{invocation.Method.Name}调用前,参数:{JsonConvert.SerializeObject(invocation.Arguments)}");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            invocation.Proceed();
            Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}方法{invocation.Method.Name}调用后,耗时:{watch.ElapsedMilliseconds}");
        }
    }



}
