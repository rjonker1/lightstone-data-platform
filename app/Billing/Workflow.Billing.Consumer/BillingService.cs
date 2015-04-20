using System;
using System.Threading.Tasks;
using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using NHibernate;
using Workflow.Billing.Consumer.Installers;
using Workflow.Billing.Consumers;
using Workflow.Billing.Domain.Entities;

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
                new RepositoryInstaller(),
                new AutoMapperInstaller(),
                new ConsumerInstaller(),
                new BusInstaller());

            //bus = container.Resolve<IBus>();
            advancedBus = container.Resolve<IAdvancedBus>();
            var q = advancedBus.QueueDeclare("DataPlatform.Transactions.Billing");
            //advancedBus.Consume(q, x => container.Resolve(typeof(IConsume<>)));
            //advancedBus.Consume(q, x => container.Resolve<TransactionConsumer>());
            advancedBus.Consume(q, x => x
                .Add<InvoiceTransactionCreated>((message, info) => new TransactionConsumer<InvoiceTransactionCreated> (message, container))
                .Add<UserMessage>((message, info) => new TransactionConsumer<UserMessage> (message, container))
                .Add<CustomerMessage>((message, info) => new TransactionConsumer<CustomerMessage>(message, container))
                .Add<ClientMessage>((message, info) => new TransactionConsumer<ClientMessage>(message, container)));

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