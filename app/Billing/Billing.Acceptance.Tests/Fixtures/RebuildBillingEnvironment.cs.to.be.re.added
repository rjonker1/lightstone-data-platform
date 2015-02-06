using Shared.Public.TestHelpers.Environment;

namespace Billing.Acceptance.Tests.Fixtures
{
    public class RebuildBillingEnvironment : ISetupEnvironment
    {
        public void Run()
        {
            Datastores.Rebuild(new[] {"Workflow.Billing.Database"}, new[] {"workflow/billing/database"});
        }
    }
}