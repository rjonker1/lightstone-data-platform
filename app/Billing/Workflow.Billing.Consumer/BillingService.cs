﻿using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers;
using Workflow.Billing.Consumers.Installers;
using Workflow.Billing.Installers;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingService>();
        private IAdvancedBus advancedBus;

        public void Start()
        {
            _log.DebugFormat("Started billing service");

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
                new ScheduleInstaller());

            advancedBus = container.Resolve<IAdvancedBus>();
            var q = advancedBus.QueueDeclare("DataPlatform.Transactions.Billing");
            
            advancedBus.Consume(q, x => x
                .Add<InvoiceTransactionCreated>((message, info) => new TransactionConsumer<InvoiceTransactionCreated> (message, container))
                .Add<UserMessage>((message, info) => new TransactionConsumer<UserMessage> (message, container))
                .Add<CustomerMessage>((message, info) => new TransactionConsumer<CustomerMessage>(message, container))
                .Add<ClientMessage>((message, info) => new TransactionConsumer<ClientMessage>(message, container))
                .Add<PackageMessage>((message, info) => new TransactionConsumer<PackageMessage>(message, container))
                .Add<ContractMessage>((message, info) => new TransactionConsumer<ContractMessage>(message, container))
                .Add<TransactionRequestMessage>((message, info) => new TransactionConsumer<TransactionRequestMessage>(message, container))
                .Add<TransactionRequestCleanupMessage>((message, info) => new TransactionConsumer<TransactionRequestCleanupMessage>(message, container)));

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