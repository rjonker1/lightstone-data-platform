using Autofac;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using EventTracking.Write.Service;
using NEventStore;
using NEventStore.Persistence.SqlPersistence.SqlDialects;

namespace EventTracking.Host.IoC
{
    public class EventTrackingModule : Module
    {


        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => BuildEventStore())
                .As<IStoreEvents>()
                .SingleInstance();

            builder.RegisterType<ConflictDetector>().As<IDetectConflicts>();
            builder.RegisterType<EventStoreRepository>().As<IRepository>();
            builder.RegisterType<AggregateFactory>().As<IConstructAggregates>();
        }

        private static IStoreEvents BuildEventStore()
        {
            return Wireup.Init()
                .LogToConsoleWindow()
                .UsingSqlPersistence("EventTracking.EventStore")
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                .UsingBinarySerialization()
                .Build();
        }
    }
}
