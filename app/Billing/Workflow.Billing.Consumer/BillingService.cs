using Castle.Windsor;
using Castle.Windsor.Installer;
using Common.Logging;
using EasyNetQ;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog log = LogManager.GetLogger<BillingService>();
        private IBus bus;

        public void Start()
        {
            log.DebugFormat("Started billing service");

            var container = new WindsorContainer().Install(FromAssembly.This());
            bus = container.Resolve<IBus>();

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