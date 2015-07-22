using Castle.Windsor;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NEventStore;
using NEventStore.Dispatcher;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Infrastructure.NEventStore;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_nventstore_dependency : Specification
    {
        public readonly IWindsorContainer _container = new WindsorContainer();
        public override void Observe()
        {
            _container.Install(new BusInstaller(), new CacheProviderInstaller() ,new NEventStoreInstaller());
        }

        [Observation]
        public void should_resolve_IDispatchCommits()
        {
            _container.Resolve<IDispatchCommits>().ShouldBeType<InMemoryDispatcher>();
        }

        [Observation]
        public void should_resolve_IStoreEvents()
        {
            _container.Resolve<IStoreEvents>().ShouldNotBeNull();
        }

        [Observation]
        public void should_resolve_IConstructAggregates()
        {
            _container.Resolve<IConstructAggregates>().ShouldBeType<AggregateFactory>();
        }

        [Observation]
        public void should_resolve_IDetectConflicts()
        {
            _container.Resolve<IDetectConflicts>().ShouldBeType<ConflictDetector>();
        }

        [Observation]
        public void should_resolve_INEventStoreRepository()
        {
            _container.Resolve<INEventStoreRepository<Package>>().ShouldBeType<NEventStoreRepository<Package>>();
        }
    }
}