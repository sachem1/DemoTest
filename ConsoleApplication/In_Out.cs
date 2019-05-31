using System;

namespace ConsoleApplication
{
    public class InOut
    {
        public static void InTest()
        {
            InConvert<Dog> a= new AnimalConvert();

            AnimalConvert.Method(new Dog());
        }

        public static void OutTest()
        {
            OutConvert<Animal> a= new IDog();
        }
    }

    public interface InConvert<in T>
    {
        /// <summary>
        /// 这里即包含了in 也包含了out
        /// </summary>
        Func<string, object> AFunc { get; set; }
    }

    public class AnimalConvert :InConvert<Animal>
    {
        public static void Method<Animal>(Animal a) { Console.WriteLine(a.GetType()); }
        public static void In(object t)
        {

            Console.WriteLine($"此时的动物类型:{t.GetType().FullName}");
        }

        public Func<string, object> AFunc { get; set; }
    }

    public class IDog : OutConvert<Dog>
    {
        
    }


    public interface OutConvert<out T>
    {
        
    }
   
}