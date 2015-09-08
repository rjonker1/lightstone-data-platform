using System;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using Hangfire;
using Hangfire.Storage;
using Microsoft.Owin.Hosting;
using Nancy;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Helpers.Schedules;
using Workflow.Billing.Messages.Publishable;

namespace Workflow.Billing.Scheduler.Service
{
    public class BillingSchedulerService : IBillingSchedulerService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingSchedulerService>();
        Url url = "http://hangfire.owin.selfhosted.with.nancy/";

        // Required for proper Job server instantiation and disposal
        private BackgroundJobServer _server;

        public void Start()
        {
            // Nancy Instantiation
            WebApp.Start<Startup>(url);

            // HangFire Instantiation
            _server = new BackgroundJobServer();

            // Wire-up existing jobs created
            var stageBillRun = new BillingMessage() { RunType = "Stage", Schedule = null };
            var finalBillRun = new BillingMessage() { RunType = "Final", Schedule = null };
            var prebillCacheRun = new BillCacheMessage
            {
                BillingType = typeof(PreBilling),
                Command = BillingCacheCommand.Reload
            };
            var stagebillCacheRun = new BillCacheMessage
            {
                BillingType = typeof(StageBilling),
                Command = BillingCacheCommand.Reload
            };
            var finalbillCacheRun = new BillCacheMessage
            {
                BillingType = typeof(FinalBilling),
                Command = BillingCacheCommand.Reload
            };

            using (var job = JobStorage.Current.GetConnection())
            {
                foreach (var recurringJob in job.GetRecurringJobs())
                {
                    if (recurringJob.Id.Contains("StageBilling Run"))
                        RecurringJob.AddOrUpdate<MessageSchedule>(recurringJob.Id, x => x.Send(stageBillRun),
                            recurringJob.Cron, TimeZoneInfo.Local);
                    if (recurringJob.Id.Contains("FinalBilling Run"))
                        RecurringJob.AddOrUpdate<MessageSchedule>(recurringJob.Id, x => x.Send(finalBillRun),
                            recurringJob.Cron, TimeZoneInfo.Local);

                    if (recurringJob.Id.Contains("PreBilling Cache Reload"))
                        RecurringJob.AddOrUpdate<CacheSchedule>(recurringJob.Id, x => x.Send(prebillCacheRun),
                            recurringJob.Cron, TimeZoneInfo.Local);
                    if (recurringJob.Id.Contains("StageBilling Cache Reload"))
                        RecurringJob.AddOrUpdate<CacheSchedule>(recurringJob.Id, x => x.Send(stagebillCacheRun),
                            recurringJob.Cron, TimeZoneInfo.Local);
                    if (recurringJob.Id.Contains("FinalBilling Cache Reload"))
                        RecurringJob.AddOrUpdate<CacheSchedule>(recurringJob.Id, x => x.Send(finalbillCacheRun),
                            recurringJob.Cron, TimeZoneInfo.Local);
                }
            }

            //RecurringJob.AddOrUpdate(() => Console.WriteLine("Hangfire Responding"), Cron.Minutely);

            Console.WriteLine("\r");
            Console.WriteLine("Running on {0}", url);
            Console.WriteLine("\r\n");
            Console.WriteLine("*----------------------------------------------------------------------------*");
            Console.WriteLine("127.0.0.1 " + url + " <-- Required Hosts Entry!");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("\r");
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}