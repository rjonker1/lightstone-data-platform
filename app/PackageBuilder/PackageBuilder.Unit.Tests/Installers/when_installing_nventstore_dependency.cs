using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NEventStore;
using NEventStore.Dispatcher;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Infrastructure.NEventStore;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_nventstore_dependency : BaseTestHelper
    {
        public override void Observe()
        {

        }

        [Observation]
        public void should_resolve_IDispatchCommits()
        {
            Container.Resolve<IDispatchCommits>().ShouldBeType<InMemoryDispatcher>();
        }

        [Observation]
        public void should_resolve_IStoreEvents()
        {
            Container.Resolve<IStoreEvents>().ShouldNotBeNull();
        }

        [Observation]
        public void should_resolve_IConstructAggregates()
        {
            Container.Resolve<IConstructAggregates>().ShouldBeType<AggregateFactory>();
        }

        [Observation]
        public void should_resolve_IDetectConflicts()
        {
            Container.Resolve<IDetectConflicts>().ShouldBeType<ConflictDetector>();
        }

        [Observation]
        public void should_resolve_INEventStoreRepository()
        {
            Container.Resolve<INEventStoreRepository<Package>>().ShouldBeType<NEventStoreRepository<Package>>();
        }
    }
}