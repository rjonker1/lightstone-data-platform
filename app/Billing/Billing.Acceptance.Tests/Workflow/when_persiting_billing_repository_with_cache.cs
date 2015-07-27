using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Workflow
{
    public class when_persiting_billing_repository_with_cache : BaseTestHelper
    {
 
        public override void Observe()
        {
        }

        [Observation]
        public void should_persist_preBilling_with_cache()
        {
            
        }
    }
}