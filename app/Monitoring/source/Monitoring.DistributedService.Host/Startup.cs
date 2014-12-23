using Monitoring.Queuing.Contracts;
using NServiceBus;

namespace Monitoring.DistributedService.Host
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
            _initializeQueues.InitializeReadQueues();
        }

        public void Stop()
        {

        }
    }
}
