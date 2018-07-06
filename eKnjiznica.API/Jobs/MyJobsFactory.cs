using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace eKnjiznica.API.Jobs
{
    public class MyJobFactory : IJobFactory

    {
        private readonly IUnityContainer _container;

        public MyJobFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _container.Resolve(bundle.JobDetail.JobType) as IJob;

        }

        public void ReturnJob(IJob job)
        {
        }
    }
}