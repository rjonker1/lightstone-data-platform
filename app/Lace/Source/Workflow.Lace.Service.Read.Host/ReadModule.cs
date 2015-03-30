using System.Configuration;
using System.Data.SqlClient;
using Autofac;
using Workflow.Billing.Repository;
using Workflow.Lace.Mappers;
using Workflow.Lace.Shared.Queuing;
using Workflow.Lace.Shared.RabbitMq;

namespace Workflow.Lace.Service.Read.Host
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
                            ConfigurationManager.ConnectionStrings["workflow/dataprovider/database/read"]
                                .ConnectionString), new RepositoryMapper(new MappingForTypes())))
                .As<IRepository>();
        }
    }
}
