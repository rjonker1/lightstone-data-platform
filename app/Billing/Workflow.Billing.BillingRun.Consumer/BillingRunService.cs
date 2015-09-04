using System;
using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Helpers.Extensions;
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
            _log.DebugFormat("Started billing run service");

            var container = new WindsorContainer().Install(
                new NHibernateInstaller(),
                new WindsorInstaller(),
                new CacheProviderInstaller(),
                new RepositoryInstaller(),
                new AutoMapperInstaller(),
                new ConsumerInstaller(),
                new BusInstaller(),
                new PublishReportQueueInstaller(),
                new PivotInstaller(),
                new NotificationInstaller());

            try
            {
                advancedBus = container.Resolve<IAdvancedBus>();
                var q = advancedBus.QueueDeclare("DataPlatform.Transactions.BillingRun");

                advancedBus.Consume(q, x => x
                    .Add<BillingMessage>((message, info) => new TransactionConsumer<BillingMessage>(message, container)));
            }
            catch (Exception e)
            {
                this.Error(() => e.Message);
            }
            _log.DebugFormat("Billing run service started");
        }

        public void Stop()
        {
            if (advancedBus != null)
            {
                advancedBus.Dispose();
            }

            _log.DebugFormat("Stopped billing run service");
        }
    }
}