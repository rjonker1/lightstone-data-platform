using System.Configuration;
using System.Data.SqlClient;
using Autofac;
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
                    new Repository.Repository(
                        new SqlConnection(ConfigurationManager.ConnectionStrings["workflow/dataprovider/database/read"].ConnectionString)))
                .As<Repository.IRepository>();
        }
    }
}
