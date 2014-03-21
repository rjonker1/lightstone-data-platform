using Common.Logging;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public void Start()
        {
            log.DebugFormat("Started billing service");
        }

        public void Stop()
        {
            log.DebugFormat("Stopped billing service");
        }
    }
}