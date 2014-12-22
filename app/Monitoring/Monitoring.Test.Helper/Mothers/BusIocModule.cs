using Autofac;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using PackageBuilder.Core.NEventStore;

namespace Monitoring.Test.Helper.Mothers
{
    public class BusIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConflictDetector>().As<IDetectConflicts>();
            // builder.RegisterType<EventStoreRepository>().As<IRepository>();
            builder.RegisterType<AggregateFactory>().As<IConstructAggregates>();
            builder.RegisterType<QueueInitialization>().As<IInitializeQueues>();
        }
    }
}
