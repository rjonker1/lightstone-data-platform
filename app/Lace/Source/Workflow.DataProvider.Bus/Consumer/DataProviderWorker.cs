using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Workflow.DataProvider.Bus.Consumer.Installers;

namespace Workflow.DataProvider.Bus.Consumer
{
    public class DataProviderWorker : IDataProviderWorker
    {
        private readonly ILog _log = LogManager.GetLogger<DataProviderWorker>();
        private IAdvancedBus _bus;

        public void Start()
        {
            _log.DebugFormat("Data Provider Command Processor Service being fired up...");

            var container = new WindsorContainer().Install(
                new WindsorInstaller(),
                new RepositoryInstaller(),
                new ConsumerInstaller(),
                new BusInstaller());

            _bus = container.Resolve<IAdvancedBus>();
            _bus
                .BindRecieverQueue(container)
                .BindSenderQueue(container)
                .BindApiReceiverQueue(container);
            _log.DebugFormat("Data Provider Command Processor Service Started");
        }

        public void Stop()
        {
            if (_bus != null)
            {
                _bus.Dispose();
            }

            _log.DebugFormat("Stopped Data Provider Command Processor Service");
        }
    }
}
