using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new winForm());

            var servicesToRun = new ServiceBase[]
            {
                new TasklService(), 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
