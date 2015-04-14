using System.Configuration;
using System.Data.SqlClient;
using Autofac;
using NServiceBus;
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
            builder.Register(c => Bus.CreateSendOnly(new BusConfiguration())).As<ISendOnlyBus>();
        }
    }
}
