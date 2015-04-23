using System;
using System.ComponentModel;
using System.Globalization;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Hangfire;
using Hangfire.Storage;
using Nancy;
using RestSharp;
using Workflow.BuildingBlocks;

using  CronExpressionDescriptor;

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
                        if(recurringJob.Id == "StageBilling Run") cronExpression = recurringJob.Cron;
                    }
                }

                return Response.AsJson(new {data = cronExpression});
            };

            Post["/Schedules/BillingRun/Daily/{runType}"] = parameters =>
            {
                var runType = parameters.runType;
                string dailyTime = Request.Query["daily_time"];

                var billRun = new BillingMessage()
                {
                    RunType = "Stage",
                    Schedule = null
                };

                DateTime dt = DateTime.ParseExact(dailyTime, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);

                var cronExpression = ""+dt.Minute+" "+dt.Hour+" * * *";

                if (runType == "StageBilling") RecurringJob.AddOrUpdate<MessageSchedule>("StageBilling Run", x => x.Send(billRun), cronExpression, TimeZoneInfo.Local);

                return null;
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

    //Class required to provide DI for TransactionBus functionality
    public class MessageSchedule
    {
        IAdvancedBus _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");

        public void Send(BillingMessage message)
        {
            var bus = new TransactionBus(_bus);
            bus.SendDynamic(new BillingMessage() {RunType = message.RunType, Schedule = message.Schedule});
        }
    }
}


//var runType = parameters.runType;
//var dateTime = this.Request.Query["schedule_time"];

//var test = DateTime.Now.AddMinutes(1);
//var billRun = new BillingMessage()
//{
//    RunType = "Stage",
//    Schedule = null
//};

//if (runType == "StageBilling") BackgroundJob.Schedule<MessageSchedule>(x => x.Send(billRun), test);