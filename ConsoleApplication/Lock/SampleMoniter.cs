using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApplication.Lock
{
    class SampleMoniter
    {
        private readonly object _obj=new object();
        public void ImitateMoniter()
        {
            bool isSuc = false;
            try
            {
                Monitor.Enter(_obj, ref isSuc);
                //dosomething
                Console.WriteLine("Locked!");
            }
            finally
            {
                if(isSuc)
                    Monitor.Exit(_obj);
            }
            Console.WriteLine("Released lock!");
        }
    }
}
