using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApplication
{
    public class ExceptionTest
    {
        /**
         
             耗费时间为:143657
             耗费时间为:0
             */
        /// <summary>
        ///
        /// </summary>
        public static void TryCatch_Test()
        {
            int length = 10000;
            int num = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < length; i++)
            {
                try
                {
                    var x = i / num;
                }
                catch (Exception)
                {

                }
            }
            Console.WriteLine($"耗费时间为:{stopwatch.ElapsedMilliseconds}");

        }

        public static void Not_TryCatch_Test()
        {
            int length = 10000;
            int num = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < length; i++)
            {
                if (num != 0)
                {
                    var x = i / num;
                }
                else
                {
                }
            }
            Console.WriteLine($"耗费时间为:{stopwatch.ElapsedMilliseconds}");

        }
    }
}
