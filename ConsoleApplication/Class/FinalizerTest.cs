namespace ConsoleApplication.Class
{
    
    public class FinalizerTest
    {

    }



    public class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("这是First实例释放!");
        }

    }

    public class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("这是Second实例释放");
        }
    }

    public class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("这是Third实例释放");
        }
    }
}
