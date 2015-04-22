using System;
using System.ComponentModel;
using System.Globalization;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Hangfire;
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
            //IAdvancedBus _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
            //var bus = new TransactionBus(_bus);

            Post["/Schedules/BillingRun/Execute/{runType}"] = parameters =>
            {
                var runType = parameters.runType;

                if (runType == "StageBilling") new MessageSchedule().Send(new BillingMessage() { RunType = runType });
                
                return Response.AsJson(new { data = "Required type: StageBilling" });
            };

            Post["/Schedules/BillingRun/Schedule/{runType}"] = parameters =>
            {
                //var runType = parameters.runType;
                //var dateTime = this.Request.Query["schedule_time"];

                //var test = DateTime.Now.AddMinutes(1);
                //var billRun = new BillingMessage()
                //{
                //    RunType = "Stage",
                //    Schedule = null
                //};

                //if (runType == "StageBilling") BackgroundJob.Schedule<MessageSchedule>(x => x.Send(billRun), test);

                return null;
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

                if (runType == "StageBilling") RecurringJob.AddOrUpdate<MessageSchedule>(x => x.Send(billRun), cronExpression);

                return null;
            };
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