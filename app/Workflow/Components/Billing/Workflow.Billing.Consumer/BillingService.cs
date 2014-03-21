using System.Collections.Generic;
using Common.Logging;
using EasyNetQ;
using Workflow.Billing.Consumers;
using Workflow.Billing.Messages;
using Workflow.BuildingBlocks;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();
        private IBus bus;

        public void Start()
        {
            log.DebugFormat("Started billing service");

            var consumers = new List<ConsumerRegistration>()
                            {
                                new ConsumerRegistration(typeof(BillTransactionMessage), 
                                    new ConsumerRegistrationConstruction(typeof(BillTransactionConsumer), () => new BillTransactionConsumer()))
                            };

            bus = new BusFactory().Create("workflow/billing/queue", consumers);

            log.DebugFormat("Billing service started");
        }

        public void Stop()
        {
            if (bus != null)
            {
                bus.Dispose();
            }

            log.DebugFormat("Stopped billing service");
        }
    }
}