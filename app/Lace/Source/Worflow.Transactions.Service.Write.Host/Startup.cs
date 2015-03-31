using NServiceBus;
using Workflow.Transactions.Shared.Queuing;

namespace Worflow.Transactions.Service.Write.Host
{
    public class Startup : IWantToRunWhenBusStartsAndStops
    {
        private readonly IInitializeQueues _initializeQueues;

        public Startup(IInitializeQueues initializeQueues)
        {
            _initializeQueues = initializeQueues;
        }
        public void Start()
        {
            _initializeQueues.InitializeAllExchanges();
            _initializeQueues.InitializeReadQueues();
        }

        public void Stop()
        {
           
        }
    }
}
