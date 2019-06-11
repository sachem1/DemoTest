using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Func
{
    class SampleFunc
    {
        public Func<string, Customer> InitCustomer;

        public Func<int, List<Customer>> CustomerList;

        public Func<string, Task<Customer>> GetCustomer;


        public Func<string, int, Customer> InitFunc;

        public void Init(Func<string,int,Customer> func)
        {
            InitFunc = func;
        }

        public void StringConvertUpper()
        {
            string Func(string str) => str.ToUpper();

            string[] strList = new [] {"the", "first", "func", "hello", "world"};

            IEnumerable<string> list = strList.Select(Func);
            StringBuilder stringBuilder=new StringBuilder();
            foreach (var item in list)
            {
                stringBuilder.Append(item);
            }
            Console.WriteLine($"StringConvertUpper:{stringBuilder}");
        }

        public void StringIndex()
        {
            string[] strList = new[] { "the", "first", "func", "hello", "world" };

            bool Predicate(string str, int index) => str.Length == index+1;

            IEnumerable<string> words = strList.Where(Predicate).Select(x => x.ToUpper());

            foreach (var item in words)
            {
                Console.WriteLine($"符合条件的是:{item}");
            }
        }

        public void StringToNumber()
        {
            int Parser(string str,NumberStyles styles,IFormatProvider provider)=>int.Parse(str,styles,provider);
            string num = "1587";
            var result=Parser(num, NumberStyles.Integer, CultureInfo.CurrentCulture);
            Console.WriteLine(result);
            
        }
    }


    class Customer
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Customer GetCustomer(string name)
        {
            return new Customer() { Name = name };
        }

        public List<Customer> GetCustomerList(int count)
        {
            List<Customer> customers = new List<Customer>();
            Parallel.For(0, count, x =>
            {
                customers.Add(new Customer());
            });
            return customers;
        }


        public Task<Customer> GeTask(string name)
        {
            return Task.FromResult(new Customer() { Name = name });
        }

        public Customer GetCustomer(string name, int age)
        {
            return new Customer() { Name = name, Age = age };
        }
    }
}
