using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jiesen.Scheduler;
using Quartz;
using Quartz.Impl;

namespace Jiesen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = RunScheduler();
            Task.WaitAll(task);
            Console.ReadLine();
        }

        private static async Task RunScheduler()
        {
            await Console.Out.WriteLineAsync("开启任务调度!");
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            //var cancelToken = new CancellationToken();
            IScheduler scheduler = await schedulerFactory.GetScheduler();

            await scheduler.Start();

            //创建job
            IJobDetail jobDetail = JobBuilder.Create<JobDemo>().WithIdentity("job", "group").Build();

            //创建触发器 ,每5秒执行一次
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger", "group")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            //加入作业调度

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
