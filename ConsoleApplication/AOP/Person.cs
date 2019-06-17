using System;
using System.Threading;
using Autofac.Extras.DynamicProxy2;

namespace ConsoleApplication.AOP
{


    [Intercept(typeof(LogInterceptor))]
    public class PersonModel:IPerson
    {
        public void Say()
        {
            Console.WriteLine("I say Aop,you say yes!");
        }
    }

    /// <summary>
    /// 非侵入式
    /// </summary>
    public class CustomerModel : IPerson {
        public void Say()
        {
            Console.WriteLine("I am New Customer");
            Thread.Sleep(100);
        }
    }
}
