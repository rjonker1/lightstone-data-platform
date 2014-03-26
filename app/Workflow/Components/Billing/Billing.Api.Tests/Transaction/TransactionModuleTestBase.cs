using System;
using Nancy.Testing;
using Workflow;
using Xunit.Extensions;

namespace Billing.Api.Tests.Transaction
{
    public abstract class TransactionModuleTestBase : Specification
    {
        private readonly Browser browser;
        protected readonly IPublishMessages publisher;
        private const string url = "/transaction";

        protected TransactionModuleTestBase(IPublishMessages publisher)
        {
            this.publisher = publisher;

            browser = new Browser(new TestingBootstrapper(publisher));
        }

        protected BrowserResponse Post(Action<BrowserContext> browserContext)
        {
            Action<BrowserContext> wrappedContext = with =>
            {
                browserContext(with);

                if (!(this is AsUnautorisedUser))
                {
                    with.Header("apikey", DateTime.Now.Millisecond.ToString());
                }

            };

            return browser.Post(url, wrappedContext);
        }
    }
}