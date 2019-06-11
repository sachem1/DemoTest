using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Class
{
    delegate void SampleDele();
    class SampleDelegate
    {
        public delegate void Del(string message);

        public static void DeleteMethod(string message)
        {
            Console.WriteLine($"删除{message}");
        }

        public static void Test()
        {
            MethodClass methodClass = new MethodClass();
            Del del1 = DeleteMethod;
            Del del2 = methodClass.Method1;
            Del del3 = methodClass.Method2;


            Del handler = del1 + del2 + del3;
            handler("Hello World");

            Console.WriteLine($"委托数量:{handler.GetInvocationList().Length}");
            Console.WriteLine($"是否同一委托:{del1 == del2}");
        }
    }

    class MethodClass
    {
        public void Method1(string message)
        {
            Console.WriteLine($"method1:{message}");
        }

        public void Method2(string message)
        {
            Console.WriteLine($"method2:{message}");
        }
    }
}
