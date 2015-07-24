using Billing.TestHelper.BaseTests;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Xunit.Extensions;

namespace Billing.Api.Tests.Workflow
{
    public class when_implementing_cache_provider : BaseTestHelper
    {
        private ICacheProvider<PreBilling> _preBillingCacheProvider;

        public override void Observe()
        {
            _preBillingCacheProvider = Container.Resolve<ICacheProvider<PreBilling>>();
        }

        [Observation]
        public void should_persist_to_cache()
        {
            //_preBillingCacheProvider.CacheSave();
        }
    }
}