using Nancy.Testing;
using Workflow;
using Xunit.Extensions;

namespace Billing.Api.Tests.Transaction
{
    public abstract class TransactionModuleTestBase : Specification
    {
        protected readonly Browser browser;
        protected readonly IPublishMessages publisher;
        protected const string url = "/transaction";

        protected TransactionModuleTestBase(IPublishMessages publisher)
        {
            this.publisher = publisher;
            browser = new Browser(with =>
            {
                with.Module<Api.Transaction>();
                with.Dependency(publisher);
            });
        }
    }
}