using System;
using System.Globalization;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using Hangfire;
using Hangfire.Storage;
using Nancy;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.Schedules;
using Workflow.Billing.Messages.Publishable;

namespace Billing.Scheduler.Modules
{
    public class ScheduleModule : NancyModule
    {

        public ScheduleModule()
        {
            Post["/Schedules/BillingRun/Execute/{runType}"] = parameters =>
            {

                var runType = parameters.runType;

                if (runType == "StageBilling") new MessageSchedule().Send(new BillingMessage() { RunType = runType });

                return Response.AsJson(new { data = "Required type: StageBilling" });
            };

            Get["/Schedules/BillingRun/Schedule/Daily"] = parameters =>
            {

                var cronExpression = "* * * * *";

                using (var job = JobStorage.Current.GetConnection())
                {

                    foreach (var recurringJob in job.GetRecurringJobs())
                    {
                        if (recurringJob.Id == "StageBilling Run") cronExpression = recurringJob.Cron;
                    }
                }

                return Response.AsJson(new { data = cronExpression });
            };

            Get["/Schedules/BillingRun/Schedule/Monthly"] = parameters =>
            {

                var cronExpression = "* * * * *";

                using (var job = JobStorage.Current.GetConnection())
                {

                    foreach (var recurringJob in job.GetRecurringJobs())
                    {
                        if (recurringJob.Id == "FinalBilling Run") cronExpression = recurringJob.Cron;
                    }
                }

                return Response.AsJson(new { data = cronExpression });
            };

            Post["/Schedules/BillingRun/Force"] = parameters =>
            {
                BackgroundJob.Enqueue(() => new MessageSchedule().Send(new BillingMessage() { RunType = "Stage", Schedule = null }));
                return Response.AsJson(new { data = "StageBilling Run Executed" });
            };

            Post["/Schedules/BillingRun/Schedule/Daily"] = parameters =>
            {

                DateTime dt;
                string dailyTime = Request.Query["daily_time"];
                string disableFlag = Request.Query["disable_schedule"];

                if (disableFlag == "false")
                {
                    RecurringJob.RemoveIfExists("StageBilling Run");
                    return Response.AsJson(new { data = "Schedule removed" });
                }

                try
                {
                    dt = DateTime.ParseExact(dailyTime, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {
                    return Response.AsJson(new { data = "Error while parsing DateTime variable" });
                }

                var billRun = new BillingMessage { RunType = "Stage", Schedule = null };
                var prebillCacheRun = new BillCacheMessage { BillingType = typeof(PreBilling), Command = BillingCacheCommand.Reload };
                var stagebillCacheRun = new BillCacheMessage { BillingType = typeof(StageBilling), Command = BillingCacheCommand.Reload };
                var finalbillCacheRun = new BillCacheMessage { BillingType = typeof(FinalBilling), Command = BillingCacheCommand.Reload };

                var cronExpression = "" + dt.Minute + " " + dt.Hour + " * * *";

                this.Info(() => "Attempting to add schedules");

                try
                {
                    this.Info(() => "Adding StageBilling Schedule");
                    RecurringJob.AddOrUpdate<MessageSchedule>("StageBilling Run", x => x.Send(billRun), cronExpression, TimeZoneInfo.Local);
                    this.Info(() => "Successfully added StageBilling Run Schedule");

                    this.Info(() => "Adding PreBilling Cache Schedule");
                    RecurringJob.AddOrUpdate<CacheSchedule>("PreBilling Cache Reload", x => x.Send(prebillCacheRun), cronExpression, TimeZoneInfo.Local);
                    this.Info(() => "Successfully added PreBilling Cache Schedule");

                    this.Info(() => "Adding StageBilling Cache Schedule");
                    RecurringJob.AddOrUpdate<CacheSchedule>("StageBilling Cache Reload", x => x.Send(stagebillCacheRun), cronExpression, TimeZoneInfo.Local);
                    this.Info(() => "Successfully added StageBilling Cache Schedule");

                    this.Info(() => "Adding FinalBilling Cache Schedule");
                    RecurringJob.AddOrUpdate<CacheSchedule>("FinalBilling Cache Reload", x => x.Send(finalbillCacheRun), cronExpression, TimeZoneInfo.Local);
                    this.Info(() => "Successfully added FinalBilling Cache Schedule");
                }
                catch (Exception ex)
                {
                    this.Error(() => ex.Message);
                    return Response.AsJson(new { data = ex.Message });
                }

                return Response.AsJson(new { data = "Schedule Added/Updated" });
            };

            Post["/Schedules/BillingRun/Schedule/Monthly"] = parameters =>
            {

                DateTime dt;
                string monthlyDateTime = Request.Query["monthly_dateTime"];
                string disableFlag = Request.Query["disable_schedule"];

                if (disableFlag == "false")
                {
                    RecurringJob.RemoveIfExists("FinalBilling Run");
                    return Response.AsJson(new { data = "Schedule removed" });
                }

                try
                {
                    dt = DateTime.ParseExact(monthlyDateTime, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {
                    return Response.AsJson(new { data = "Error while parsing DateTime variable" });
                }

                var billRun = new BillingMessage() { RunType = "Final", Schedule = null };
                var cronExpression = "" + dt.Minute + " " + dt.Hour + " " + dt.Day + " * *";

                RecurringJob.AddOrUpdate<MessageSchedule>("FinalBilling Run", x => x.Send(billRun), cronExpression, TimeZoneInfo.Local);

                return Response.AsJson(new { data = "Schedule Added/Updated" });
            };

            //CORS for Module
            After.AddItemToEndOfPipeline(nancyContext =>
            {
                nancyContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });
        }
    }
}