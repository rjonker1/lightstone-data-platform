using System;
using System.Reflection;
using Castle.Windsor;
using Common.Logging;
using Quartz;
using Quartz.Spi;

namespace Lace.Caching.Manager.Service.Jobs
{
    public class JobFactory : IJobFactory
    {
         private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IWindsorContainer _container;

        public JobFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, Quartz.IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            var jobType = jobDetail.JobType;

            try
            {
                Log.Debug(string.Format("Creating job '{0}' of type {1}", jobDetail.Description, jobType.FullName));

                return _container.Resolve(jobType) as IJob;
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Failed to create job of type {0}, because {1}", jobType, e);
                throw new SchedulerException(string.Format("Problem creating job '{0}'", jobDetail.JobType.FullName), e);
            }
        }

        public void ReturnJob(IJob job)
        {
            if (job == null)
                return;

            _container.Release(job);
        }
    }
}
