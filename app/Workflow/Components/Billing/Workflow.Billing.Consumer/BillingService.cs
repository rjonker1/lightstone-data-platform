using Common.Logging;
using EasyNetQ;
using Workflow.Billing.Consumers;
using Workflow.Billing.Messages;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Consumers;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();
        private IBus bus;

        public void Start()
        {
            log.DebugFormat("Started billing service");

            var consumers = new ConsumerRegistration()
                .AddConsumer<BillTransactionConsumer, BillTransactionMessage>(() => new BillTransactionConsumer());

            bus = new BusFactory().CreateConsumerBus("workflow/billing/queue", consumers);

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