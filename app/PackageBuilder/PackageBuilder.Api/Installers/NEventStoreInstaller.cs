using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NEventStore;
using NEventStore.Dispatcher;
using NEventStore.Persistence.Sql.SqlDialects;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Infrastructure.NEventStore;

namespace PackageBuilder.Api.Installers
{
    public class NEventStoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDispatchCommits>().ImplementedBy<InMemoryDispatcher>().LifestyleTransient());

            var eventStore = Wireup.Init()
                .LogToConsoleWindow()
                //.UsingRavenPersistence("packageBuilder/database")
                .UsingSqlPersistence("packageBuilder")
                .WithDialect(new MsSqlDialect())
                //.EnlistInAmbientTransaction() // two-phase commit
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                //.Compress()
                //.EncryptWith(new byte[]
                //{ //todo: specify encryption string
                //    0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
                //})
                .HookIntoPipelineUsing(new[] {new AuthorizationPipelineHook()})
                .UsingSynchronousDispatchScheduler()
                .DispatchTo(container.Resolve<IDispatchCommits>())
                .Build();

            
            container.Register(Component.For<IStoreEvents>().Instance(eventStore));
            container.Register(Component.For<IConstructAggregates>().ImplementedBy<AggregateFactory>().LifestyleTransient());
            container.Register(Component.For<IDetectConflicts>().ImplementedBy<ConflictDetector>().LifestyleTransient());
            container.Register(Component.For(typeof(INEventStoreRepository<>)).ImplementedBy(typeof(NEventStoreRepository<>)).LifestyleTransient());
        }
    }
}