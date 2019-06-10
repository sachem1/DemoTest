using System;
using ConsoleApplication.Class;

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

            //RefOut.Out_Test(out int param2);
            //Console.WriteLine($"out:{param2}");

            //Person person = new Person();
            //person.Name = "张三";
            //person.Address = "上海静安区";
            //person.Weight = "70";

            //Order.Number = "123";
            //Order.OrderName = "ceshi";

            //Third third = new Third();

            var index=new IndexDevice<string>();
            index[0] = "Hello";
            index[1] = "World";

            Console.WriteLine($"index: {index[0]},{index[1]}");


            var collection = new SampleCollection<string>();
            collection.Add("Hello");
            collection.Add("World");
            Console.WriteLine($"collection: {collection[0]},{collection[1]}");

            Publisher publisher=new Publisher();
            Subscriber subscriber1=new Subscriber("张三",publisher);
            Subscriber subscriber2 = new Subscriber("lisi", publisher);

            publisher.DoSomething();
            int a = 0;
            int b = 0;
            //if(a??=b)
            Console.ReadLine();
        }
    }
}
