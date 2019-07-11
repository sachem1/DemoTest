using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApplication
{
    public class ThreadTest
    {
        /**
         SpinWait.SpinUntil在执行等待时，会先进行自旋。
            所谓自旋就是在CPU运转的周期内，如果条件满足了，就不会再进入内核等待（即暂停该线程，等待一段时间后，再继续运行该线程），
            如果条件不满足，才进入内核等待。这样一来，SpinWait会比Thread.Sleep多运行一次的CPU周期，再进入等待。
            因为CPU周期是很短的(现在一般的电脑都有2.1GHZ以上)，所以这个等待对时间影响不大，却可以提升很大的性能!
            说白了Thread.Sleep 对线程会暂停和恢复的动作
             */
        /// <summary>
        /// 
        /// </summary>
        private static int _timeout_ms = 0;
        public static void SpinWaitTrueTime()
        {
            Thread thread = new Thread(() =>
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 1; i++)
                {
                    SpinWait.SpinUntil(() => true, _timeout_ms);
                }
                Console.WriteLine("SpinWait true Consume Time:{0}", sw.Elapsed.ToString());
            });
            thread.IsBackground = true;
            thread.Start();
        }
        public static void SpinWaitFalseTime()
        {
            Thread thread = new Thread(() =>
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 1; i++)
                {
                    SpinWait.SpinUntil(() => false, _timeout_ms);
                }
                Console.WriteLine("SpinWait false Consume Time:{0}", sw.Elapsed.ToString());
            });
            thread.IsBackground = true;
            thread.Start();
        }
        public static void ThreadTime()
        {
            Thread thread = new Thread(() =>
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 1; i++)
                {
                    Thread.Sleep(_timeout_ms);
                }
                Console.WriteLine("Thread Sleep Consume Time:{0}", sw.Elapsed.ToString());
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
