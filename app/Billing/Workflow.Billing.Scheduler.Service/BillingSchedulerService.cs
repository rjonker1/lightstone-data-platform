using System;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using Hangfire;
using Hangfire.Storage;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Helpers.Schedules;
using Workflow.Billing.Messages.Publishable;

namespace Workflow.Billing.Scheduler.Service
{
    public class BillingSchedulerService : IBillingSchedulerService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingSchedulerService>();
        private BackgroundJobServer _server;

        public void Start()
        {
            _server = new BackgroundJobServer();

            // Wire-up existing jobs created
            var stageBillRun = new BillingMessage() { RunType = "Stage", Schedule = null };
            var finalBillRun = new BillingMessage() { RunType = "Final", Schedule = null };
            var prebillCacheRun = new BillCacheMessage { BillingType = typeof(PreBilling), Command = BillingCacheCommand.Reload };
            var stagebillCacheRun = new BillCacheMessage { BillingType = typeof(StageBilling), Command = BillingCacheCommand.Reload };
            var finalbillCacheRun = new BillCacheMessage { BillingType = typeof(FinalBilling), Command = BillingCacheCommand.Reload };

            using (var job = JobStorage.Current.GetConnection())
            {

                foreach (var recurringJob in job.GetRecurringJobs())
                {
                    if (recurringJob.Id.Contains("StageBilling Run")) RecurringJob.AddOrUpdate<MessageSchedule>(recurringJob.Id, x => x.Send(stageBillRun), recurringJob.Cron, TimeZoneInfo.Local);
                    if (recurringJob.Id.Contains("FinalBilling Run")) RecurringJob.AddOrUpdate<MessageSchedule>(recurringJob.Id, x => x.Send(finalBillRun), recurringJob.Cron, TimeZoneInfo.Local);

                    if (recurringJob.Id.Contains("PreBilling Cache Reload")) RecurringJob.AddOrUpdate<CacheSchedule>(recurringJob.Id, x => x.Send(prebillCacheRun), recurringJob.Cron, TimeZoneInfo.Local);
                    if (recurringJob.Id.Contains("StageBilling Cache Reload")) RecurringJob.AddOrUpdate<CacheSchedule>(recurringJob.Id, x => x.Send(stagebillCacheRun), recurringJob.Cron, TimeZoneInfo.Local);
                    if (recurringJob.Id.Contains("FinalBilling Cache Reload")) RecurringJob.AddOrUpdate<CacheSchedule>(recurringJob.Id, x => x.Send(finalbillCacheRun), recurringJob.Cron, TimeZoneInfo.Local);
                }
            }
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}