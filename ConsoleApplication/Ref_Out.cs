using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class RefOut
    {
        public static void Ref_Test(ref int param)
        {
            
        }

        public static void Out_Test(out int param)
        {
            param = 1;
        }
    }
}
