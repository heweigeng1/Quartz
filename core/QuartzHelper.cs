using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Threading;

namespace core
{
    public class QuartzHelper : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }
        public void star()
        {
            //创建一个作业池
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();
            //创建一个作业
            IJobDetail job = JobBuilder.Create<QuartzHelper>().Build();
            //ITrigger trigger = TriggerBuilder.Create().StartNow().Build();
            //新建一个触发器
            //ITrigger trigger = (ICronTrigger)TriggerBuilder.Create().StartAt(DateTime.Now).EndAt(DateTime.Now.AddDays(1)).WithCronSchedule("1,10,14 1,10,20,25,26,33,54 * * * ? ").Build();
            //定义一个触发器
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create().StartAt(DateTime.Now).EndAt(DateTime.Now.AddDays(100))
                                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).WithRepeatCount(1000))
                                        .Build();
            scheduler.ScheduleJob(job, trigger);
            scheduler.Start();
            //Thread.Sleep(1000*5);//延迟执行
        }
    }
}
