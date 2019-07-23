using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jiesen.Common;
using Quartz;

namespace Jiesen.Scheduler
{
    public class JobDemo:IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var msg = "job执行...";
            //LogManager.AppendLogFile(msg);
            //return Task.FromResult(msg);
            await Console.Out.WriteLineAsync(msg);
        }
    }
}
