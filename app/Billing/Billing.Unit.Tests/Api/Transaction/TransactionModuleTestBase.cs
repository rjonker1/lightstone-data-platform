using System;
using Nancy.Testing;
using Workflow;
using Xunit.Extensions;

namespace Billing.Api.Tests.Api.Transaction
{
    public abstract class TransactionModuleTestBase : Specification
    {
        private readonly Browser browser;
        protected readonly IPublishMessages publisher;
        private readonly TestingBootstrapper bootstrapper;
        private const string url = "/transaction";

        protected TransactionModuleTestBase(IPublishMessages publisher)
        {
            this.publisher = publisher;

            bootstrapper = new TestingBootstrapper(publisher);
            browser = new Browser(bootstrapper);
        }

        protected BrowserResponse Post(Action<BrowserContext> browserContext)
        {
            Action<BrowserContext> wrappedContext = with =>
            {
                browserContext(with);

                if (!(this is AsUnautorisedUser))
                {
                    with.Header("apikey", DateTime.UtcNow.Millisecond.ToString());
                }

            };

            return browser.Post(url, wrappedContext);
        }

        ~TransactionModuleTestBase()
        {
            bootstrapper.Dispose();
        }
    }
}