using System;
using NServiceBus;
using Workflow.Lace.Shared.Queuing;

namespace Worflow.Lace.Service.Write.Host
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
