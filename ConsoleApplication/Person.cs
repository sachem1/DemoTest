using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class Person : Base
    {
        public string Name { get; set; }

        internal string Address { get; set; }

        protected string Height { get; set; }

        private string Phone { get; set; }

        protected  internal string Weight { get; set; }
       
        private string @bool { get; set; }

        public Person()
        {
            Age = 5;
            @bool = "字符串";
            Base bBase = new Base();
            bBase.GetNum(bBase);
            Console.WriteLine("");
        }
    }


    public static class Order
    {
        public static string OrderName { get; set; }

        private static string Address { get; set; }

        internal static string Number { get; set; }

        
    }
}
