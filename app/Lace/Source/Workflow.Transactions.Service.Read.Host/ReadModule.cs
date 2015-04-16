using System.Configuration;
using System.Data.SqlClient;
using Autofac;
using EasyNetQ;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;
using Workflow.Billing.Messages;
using Workflow.BuildingBlocks;
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
                                .ConnectionString), new RepositoryMapper(new MappingTransactionTypes())))
                .As<ITransactionRepository>();
            //builder.Register(
                //c =>
                //    new Repository(
                //        new SqlConnection(
                //            ConfigurationManager.ConnectionStrings["monitoring/database/read"]
                //                .ConnectionString), new RepositoryMapper(new MappingForMonitoringTypes())))
                //.As<IMonitoringRepository>();
            builder.Register(
                c =>
                    BusFactory.CreateAdvancedBus(
                        ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString))
                .As<IAdvancedBus>();
            
        }
    }
}
