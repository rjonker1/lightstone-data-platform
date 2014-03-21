using Common.Logging;
using EasyNetQ;
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

            bus = new BusFactory().Create("workflow/billing/queue");

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