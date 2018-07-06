using eKnjiznica.API.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Unity;

namespace eKnjiznica.API.App_Start
{
    public class QuartzConfig
    {
        public static void Config(IUnityContainer container)
        {

            // get a scheduler
            IScheduler sched = container.Resolve<ISchedulerFactory>().GetScheduler().Result;
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<AuctionCrawlerJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            int refreshInterval = int.Parse(ConfigurationManager.AppSettings["AuctionEmailCrawlerIntervalInSeconds"]);
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
              .WithIntervalInSeconds(refreshInterval)
                  .RepeatForever())
              .Build();

            sched
                .ScheduleJob(job, trigger);
        }
    }
}