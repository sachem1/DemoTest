using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using ConsoleApplication.Algorithm;
using ConsoleApplication.AOP;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int param1 = 0;//需赋值

            //RefOut.Ref_Test(ref param1);
            //Console.WriteLine($"ref:{param1}");
            {

                //RefOut.Out_Test(out int param2);
                //Console.WriteLine($"out:{param2}");

                //RefOut refOut = new RefOut();


                //InOut.FuncTest();
            }
            {
                //in 父类传入子类 ,out 子类转给父类
                //Func<object, ArgumentException> func = null;
                //Func<string, Exception> func2 = func;
                //Exception e = func2("");

            }
            //Person person = new Person();
            //person.Name = "张三";
            //person.Address = "上海静安区";
            //person.Weight = "70";

            //Order.Number = "123";
            //Order.OrderName = "ceshi";

            //Third third = new Third();
            //{
            //    var index = new IndexDevice<string>();
            //    index[0] = "Hello";
            //    index[1] = "World";

            //    Console.WriteLine($"index: {index[0]},{index[1]}");


            //    var collection = new SampleCollection<string>();
            //    collection.Add("Hello");
            //    collection.Add("World");
            //    Console.WriteLine($"collection: {collection[0]},{collection[1]}");
            //}

            //{
            //    Publisher publisher = new Publisher();
            //    Subscriber subscriber1 = new Subscriber("张三", publisher);
            //    Subscriber subscriber2 = new Subscriber("lisi", publisher);

            //    publisher.DoSomething();
            //}

            //{
            //    SampleDelegate.Test();
            //}

            {
                //Customer person = new Customer();
                //SampleFunc sampleFunc = new SampleFunc {InitCustomer = person.GetCustomer};
                //var xx = sampleFunc.GetCustomer = person.GeTask;
                //sampleFunc.CustomerList = person.GetCustomerList;
                //sampleFunc.Init(person.GetCustomer);
                //var zz = xx("张三");
                //Console.WriteLine($"名字:{zz.Result.Name}");

                //sampleFunc.StringConvertUpper();
                //sampleFunc.StringIndex();
            }
            //{
            //    Test test=new Test();
            //    var i = 10;
            //    Console.WriteLine(test.Add(i));
            //}

            //{
            //    var builder = new ContainerBuilder();
            //    //builder.RegisterType<PersonModel>().As<IPerson>().EnableInterfaceInterceptors();
            //    builder.RegisterType<CustomerModel>().As<IPerson>().EnableInterfaceInterceptors()
            //        .InterceptedBy(typeof(LogInterceptor));
            //    builder.RegisterType<LogInterceptor>();
            //    using (var containter = builder.Build())
            //    {
            //        containter.Resolve<IPerson>().Say();
            //    }
            //}
            //{
            //    Child child = new Child();
            //    child.Print();

            //    Parent parent = new Child();
            //    parent.Print();


            //    Third third = new Third();
            //    third.Print();
            //}

            //{
            //    SampleInterlocked interlocked=new SampleInterlocked();
            //    Parallel.For(0, 10, (i,state) =>
            //    {
            //        interlocked.LoadData();
            //    });
            //}
            //{
            //    ThreadTest.SpinWaitTrueTime();
            //    ThreadTest.SpinWaitFalseTime();
            //    ThreadTest.ThreadTime();
            //}

            {
                //ExceptionTest.TryCatch_Test();
                //ExceptionTest.Not_TryCatch_Test();

                //Combination combination = new Combination();
                //string[] items = { "one", "two", "three" };
                //foreach (string[] permutation in Combination.GetPermutations(items))
                //{
                //    Console.WriteLine(String.Join(", ", permutation));
                //}
                List<int> list = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    list.Add(i);
                }
                var result= Combination.GetKCombs(list, 3);
                foreach (var item in result)
                {
                    Console.WriteLine(string.Join(",",item));
                    Console.WriteLine("\r\n");
                }
            }
            Console.ReadLine();
        }

        public class Test
        {

            public int Add(int n)
            {
                n += 5;
                return n;
            }
        }
    }
}
