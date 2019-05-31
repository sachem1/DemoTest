using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int param1 = 0;//需赋值

            RefOut.Ref_Test(ref param1);
            Console.WriteLine($"ref:{param1}");

            RefOut.Out_Test(out int param2);
            Console.WriteLine($"out:{param2}");

            Console.ReadLine();
        }
    }
}
