using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging;
using Workflow.BuildingBlocks.Configurations;
using IWorkflowSubscriber = Workflow.Bus.Subscribers.IWorkflowSubscriber;

namespace Workflow.Bus
{
    public class WorkflowBusService : IWorkflowBusService
    {
        private readonly ILog _log = LogManager.GetLogger<WorkflowBusService>();
        private readonly IWindsorContainer _container;
        private readonly IWorkflowSubscriber _subscriber;

        public WorkflowBusService(IWorkflowSubscriber subscriber, IWindsorContainer container)
        {
            _container = container;
            _subscriber = subscriber;
        }

        public void Start()
        {
            _log.InfoFormat("Starting {0} service", ConfigurationReader.Bus.DisplayName);
            var dispatcher = new WindsorMessageDispatcher(_container);

            // ReSharper disable once ConvertClosureToMethodGroup
            _subscriber.Subscribe<IPublishableMessage>(msg => dispatcher.Dispatch<IPublishableMessage>(msg));

            _log.InfoFormat("Started {0} service", ConfigurationReader.Bus.DisplayName);
        }

        public void Stop()
        {
            _log.InfoFormat("Shutting down {0} service", ConfigurationReader.Bus.DisplayName);
        }
    }
}