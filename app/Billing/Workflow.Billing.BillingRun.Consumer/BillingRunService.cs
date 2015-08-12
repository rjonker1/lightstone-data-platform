using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Workflow.Billing.Consumers;
using Workflow.Billing.Consumers.Installers;
using Workflow.Billing.Installers;

namespace Workflow.Billing.BillingRun.Consumer
{
    public class BillingRunService : IBillingRunService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingRunService>();
        private IAdvancedBus advancedBus;

        public void Start()
        {
            _log.DebugFormat("Started billing cache service");

            var container = new WindsorContainer().Install(
                new NHibernateInstaller(),
                new WindsorInstaller(),
                new CacheProviderInstaller(),
                new RepositoryInstaller(),
                new ConsumerInstaller(),
                new BusInstaller());

            advancedBus = container.Resolve<IAdvancedBus>();
            var cache = advancedBus.QueueDeclare("DataPlatform.BillingRun");

            advancedBus.Consume(cache, x => x
                .Add<BillingMessage>((message, info) => new TransactionConsumer<BillingMessage>(message, container)));

            _log.DebugFormat("Billing cache service started");
        }

        public void Stop()
        {
            if (advancedBus != null)
            {
                advancedBus.Dispose();
            }

            _log.DebugFormat("Stopped billing cache service");
        }
    }
}