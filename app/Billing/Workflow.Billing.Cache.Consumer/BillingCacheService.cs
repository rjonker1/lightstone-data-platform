using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Workflow.Billing.Consumers;
using Workflow.Billing.Consumers.Installers;
using Workflow.Billing.Installers;
using Workflow.Billing.Messages.Publishable;

namespace Workflow.Billing.Cache.Consumer
{
    public class BillingCacheService : IBillingCacheService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingCacheService>();
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
            var cache = advancedBus.QueueDeclare("DataPlatform.Cache.Billing");

            advancedBus.Consume(cache, x => x
                .Add<BillCacheMessage>((message, info) => new TransactionConsumer<BillCacheMessage>(message, container)));

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