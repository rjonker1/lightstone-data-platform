﻿using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Workflow.Billing.Consumer.Installers;
using Workflow.Billing.Consumers;
using Workflow.Billing.Consumers.ConsumerTypes;
using Workflow.Billing.Messages.Publishable;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingService>();
        //private IBus bus;
        private IAdvancedBus advancedBus;

        public void Start()
        {
            _log.DebugFormat("Started billing service");

            var container = new WindsorContainer().Install(
                new NHibernateInstaller(),
                new WindsorInstaller(),
                // new MappingTypeInstaller(), //TODO: remove
                new CacheProviderInstaller(),
                new RepositoryInstaller(),
                new AutoMapperInstaller(),
                new ConsumerInstaller(),
                new BusInstaller(),
                new PublishReportQueueInstaller(),
                new PivotInstaller());

            //bus = container.Resolve<IBus>();
            advancedBus = container.Resolve<IAdvancedBus>();
            var q = advancedBus.QueueDeclare("DataPlatform.Transactions.Billing");
            var cache = advancedBus.QueueDeclare("DataPlatform.Cache.Billing");

            //advancedBus.Consume(q, x => container.Resolve(typeof(IConsume<>)));
            //advancedBus.Consume(q, x => container.Resolve<TransactionConsumer>());
            advancedBus.Consume(q, x => x
                .Add<BillingMessage>((message, info) => new TransactionConsumer<BillingMessage>(message, container))
                .Add<InvoiceTransactionCreated>((message, info) => new TransactionConsumer<InvoiceTransactionCreated> (message, container))
                .Add<UserMessage>((message, info) => new TransactionConsumer<UserMessage> (message, container))
                .Add<CustomerMessage>((message, info) => new TransactionConsumer<CustomerMessage>(message, container))
                .Add<ClientMessage>((message, info) => new TransactionConsumer<ClientMessage>(message, container))
                .Add<PackageMessage>((message, info) => new TransactionConsumer<PackageMessage>(message, container))
                .Add<ContractMessage>((message, info) => new TransactionConsumer<ContractMessage>(message, container)));

            advancedBus.Consume(cache, x => x
                .Add<BillCacheMessage>((message, info) => new TransactionConsumer<BillCacheMessage>(message, container)));

            _log.DebugFormat("Billing service started");
        }

        public void Stop()
        {
            if (advancedBus != null)
            {
                advancedBus.Dispose();
            }

            _log.DebugFormat("Stopped billing service");
        }
    }

}