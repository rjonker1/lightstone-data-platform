using Billing.TestHelper.BaseTests;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Xunit.Extensions;

namespace Billing.Api.Tests.Workflow
{
    public class when_installing_cache_provider_dependency : BaseTestHelper
    {
        private ICacheProvider<PreBilling> _preBillingCacheProvider;

        public override void Observe()
        {
        }

        [Observation]
        public void should_resolve_ICacheProvider_PreBilling()
        {
            Container.Resolve<ICacheProvider<PreBilling>>().ShouldBeType<CacheProvider<PreBilling>>();
        }

        [Observation]
        public void should_resolve_ICacheProvider_StageBilling()
        {
            Container.Resolve<ICacheProvider<StageBilling>>().ShouldBeType<CacheProvider<StageBilling>>();
        }

        [Observation]
        public void should_resolve_ICacheProvider_FinalBilling()
        {
            Container.Resolve<ICacheProvider<FinalBilling>>().ShouldBeType<CacheProvider<FinalBilling>>();
        }
    }
}