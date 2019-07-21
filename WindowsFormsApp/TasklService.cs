using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp
{
    partial class TasklService : ServiceBase
    {
        public TasklService()
        {
            InitializeComponent();
        }

        private System.Timers.Timer _writeLogTimer;
        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            _writeLogTimer=new Timer(2000);
            _writeLogTimer.Enabled = true;
            _writeLogTimer.Elapsed += _writeLogTimer_Elapsed;
            _writeLogTimer.Start();
        }

        private void _writeLogTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteLogService writeLogService=new WriteLogService();
            writeLogService.AppendLogFile();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            Console.WriteLine("服务已停止!");
            _writeLogTimer.Enabled = false;
        }
    }
}
