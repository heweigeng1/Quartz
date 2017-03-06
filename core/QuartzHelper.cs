using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace core
{
    public class QuartzHelper:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }
        public void star()
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<QuartzHelper>().WithIdentity("QuartzHelper", "JobGroup1").Build();
            //ITrigger trigger = TriggerBuilder.Create().StartNow().Build();
            ITrigger trigger = new CronTriggerImpl("CronTrigger", "TriggerGroup1", "0 0 12 * * ?");
            scheduler.ScheduleJob(job, trigger);
            Thread.Sleep(1000*5);//延迟执行
        }
    }
}
