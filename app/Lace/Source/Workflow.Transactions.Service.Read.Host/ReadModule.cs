using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Autofac;
using DataPlatform.Shared.Messaging;
using NEventStore;
using NEventStore.Dispatcher;
using NServiceBus;
using NServiceBus.Features;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Repository;
using Workflow.Lace.Mappers;
using Workflow.Transactions.Shared.Queuing;
using Workflow.Transactions.Shared.RabbitMq;

namespace Workflow.Transactions.Service.Read.Host
{
    public class ReadModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RabbitConsumer>().As<IConsumeQueue>();
            builder.RegisterType<QueueInitialization>().As<IInitializeQueues>();
            builder.Register(
                c =>
                    new Repository(
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["workflow/transactions/database/read"]
                                .ConnectionString), new RepositoryMapper(new MappingForTypes())))
                .As<IRepository>();
            builder.Register(c => BillingTransactionsBus()).As<ISendOnlyBus>();
        }
        
        public ISendOnlyBus BillingTransactionsBus()
        {
            var assembliesToScan =
                AllAssemblies.Matching("Lightstone.DataPlatform.Workflow.Transactions.Read.Service")
                    .And("NServiceBus.Transports.RabbitMQ");
            //return
            //    new DataPlatform.Shared.Messaging.RabbitMQ.BusFactory("Shared.Messaging.Billing.Messages",
            //        assembliesToScan,
            //        "DataPlatform.Transactions.Billing").CreateBusWithInMemoryPersistence();


            var configuration = new BusConfiguration();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.EndpointName("DataPlatform.Transactions.Billing");
            configuration.AssembliesToScan(assembliesToScan);
           // configuration.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.Contains("Workflow.Lace.Messages.Events"));
          //  configuration.Conventions().DefiningEventsAs(t => t.Namespace != null && t.Namespace.Contains("Workflow.Lace.Messages.Events"));
          //  configuration.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.typ.Contains("Workflow.Lace.Messages.Events"));
            return Bus.CreateSendOnly(configuration);

           

            //var assembliesToScan =
            //    AllAssemblies.Matching("Lightstone.DataPlatform.Shared.Messaging.Billing")
            //        .And("NServiceBus.Transports.RabbitMQ");
            ////return
            ////    new DataPlatform.Shared.Messaging.RabbitMQ.BusFactory("Shared.Messaging.Billing.Messages",
            ////        assembliesToScan,
            ////        "DataPlatform.Transactions.Billing").CreateBusWithInMemoryPersistence();


            //var configuration = new BusConfiguration();

            //configuration.UseTransport<RabbitMQTransport>();
            //configuration.UsePersistence<InMemoryPersistence>();
            //configuration.DisableFeature<TimeoutManager>();
            //configuration.EndpointName("DataPlatform.Transactions.Billing");
            //configuration.AssembliesToScan(assembliesToScan);
            //configuration.Conventions()
            //    .DefiningCommandsAs(
            //        c => c.Namespace != null && c.Namespace.Equals("Shared.Messaging.Billing.Messages"));
            //var bus = Bus.Create(configuration);
            //return bus;
        }
    }
}
