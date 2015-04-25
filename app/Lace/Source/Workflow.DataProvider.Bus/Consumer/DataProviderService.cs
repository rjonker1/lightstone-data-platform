using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.DataProvider.Bus.Consumer.Installers;
using Workflow.DataProvider.Bus.ConsumerTypes;

namespace Workflow.DataProvider.Bus.Consumer
{
    public class DataProviderService : IDataProviderService
    {
        private readonly ILog _log = LogManager.GetLogger<DataProviderService>();
        private IAdvancedBus _bus;

        public void Start()
        {
            _log.DebugFormat("Data Provider Service");

            var container = new WindsorContainer().Install(
                new WindsorInstaller(),
                new RepositoryInstaller(),
                new ConsumerInstaller(),
                new BusInstaller());

            _bus = container.Resolve<IAdvancedBus>();
            var commandQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Commands");
            var commandExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Commands", ExchangeType.Fanout);
            _bus.Bind(commandExchange, commandQueue, string.Empty);

            var eventQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Events");
            var eventExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Events", ExchangeType.Fanout);
            _bus.Bind(eventExchange, eventQueue, string.Empty);

            _bus.Consume(commandQueue, x => x
                .Add<SendRequestToDataProviderCommand>((message, info) => new CommandConsumers<SendRequestToDataProviderCommand>(message, container)));

            _log.DebugFormat("Data Provider Service Started");
        }

        public void Stop()
        {
            if (_bus != null)
            {
                _bus.Dispose();
            }

            _log.DebugFormat("Stopped Data Provider Service");
        }
    }
}
