using System;
using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using NHibernate;
using Workflow.Billing.Consumer.Installers;
using Workflow.Billing.Consumers;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingService>();
        private IBus bus;
        private IAdvancedBus advancedBus;

        public void Start()
        {
            _log.DebugFormat("Started billing service");

            var container = new WindsorContainer().Install(
                new NHibernateInstaller(),
                new WindsorInstaller(),
               // new MappingTypeInstaller(), //TODO: remove
                new RepositoryInstaller(),
                new AutoMapperInstaller(),
                new ConsumerInstaller(),
                new BusInstaller());

            //bus = container.Resolve<IBus>();
            advancedBus = container.Resolve<IAdvancedBus>();
            var q = advancedBus.QueueDeclare("TESTQUEUE1");
            //advancedBus.Consume(q, x => container.Resolve(typeof(IConsume<>)));
            //advancedBus.Consume(q, x => container.Resolve<TransactionConsumer>());
            advancedBus.Consume(q, x => x
                .Add<InvoiceTransactionCreated>((message, info) => new TransactionConsumer(new Repository<Transaction>(container.Resolve<ISession>()),
                                                                                new Repository<UserMeta>(container.Resolve<ISession>()),
                                                                                new Repository<PreBilling>(container.Resolve<ISession>()),
                                                                                new Repository<DataProviderTransaction>(container.Resolve<ISession>()),
                                                                                new Repository<Product>(container.Resolve<ISession>()),
                                                                                message))
                );

            _log.DebugFormat("Billing service started");
        }

        public void Stop()
        {
            if (bus != null)
            {
                bus.Dispose();
            }

            _log.DebugFormat("Stopped billing service");
        }
    }
}