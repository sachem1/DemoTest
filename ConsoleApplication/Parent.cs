using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class Parent
    {
        public virtual  void Print()
        {
            Console.WriteLine($"打印父类内容");
        }
    }

    class Child :Parent
    {
        public override void Print()
        {
            Console.WriteLine($"打印子类内容");
        }
    }

    class Third : Parent
    {
        public new void Print()
        {
            Console.WriteLine($"打印Third类内容");
        }
    }
}
