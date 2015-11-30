using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging;
using Workflow.Publisher;
using Workflow.Publisher.Configurations;

namespace Workflow.Bus
{
    public class WorkflowBusService : IWorkflowBusService
    {
        private readonly ILog _log = LogManager.GetLogger<WorkflowBusService>();
        private readonly IWindsorContainer _container;
        private readonly IWorkflowBus _bus;

        public WorkflowBusService(IWorkflowBus bus, IWindsorContainer container)
        {
            _container = container;
            _bus = bus;
        }

        public void Start()
        {
            _log.InfoFormat("Starting {0} service", ConfigurationReader.Bus.DisplayName);
            var dispatcher = new WindsorMessageDispatcher(_container);

            // ReSharper disable once ConvertClosureToMethodGroup
            _bus.Subscribe<IPublishableMessage>(msg => dispatcher.Dispatch<IPublishableMessage>(msg));

            _log.InfoFormat("Started {0} service", ConfigurationReader.Bus.DisplayName);
        }

        public void Stop()
        {
            _log.InfoFormat("Shutting down {0} service", ConfigurationReader.Bus.DisplayName);
        }
    }
}