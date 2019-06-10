using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class Base
    {
        protected  int Age { get; set; }

        private int Num { get; set; }

        protected internal  string TeZ {get;set;}

        public void GetNum(Base b)
        {
            b.Num = Num;
        }
    }
}
