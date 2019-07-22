using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            this.Committed += ProjectInstaller_Committed;
        }
        /*
         启动服务
         1.切换到C:\Windows\Microsoft.NET\Framework64\v4.0.30319 目录
         2.InstallUtil.exe L:\Work\GitRepository\DemoTest\WindowsFormsApp\bin\Debug\WindowsFormsApp.exe
         卸载服务
         1.切换到C:\Windows\Microsoft.NET\Framework64\v4.0.30319 目录
         2.InstallUtil.exe /u L:\Work\GitRepository\DemoTest\WindowsFormsApp\bin\Debug\WindowsFormsApp.exe
             
         */

        private void ProjectInstaller_Committed(object sender, InstallEventArgs e)
        {
           
        }
    }
}
