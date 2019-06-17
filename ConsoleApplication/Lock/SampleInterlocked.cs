using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApplication.Lock
{
    class SampleInterlocked
    {
        private int i = 0;
        public void LoadData()
        {

            if (Interlocked.Exchange(ref i, 1) == 0)
            {
                Console.WriteLine("首次初始化");
            }
            else
            {
                Console.WriteLine("重复初始化");
            }
        }
    }
}
