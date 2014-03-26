using Nancy.TinyIoc;
using Workflow;

namespace Billing.Api.Tests
{
    public class TestingBootstrapper : Bootstrapper
    {
        private readonly IPublishMessages publisher;

        public TestingBootstrapper(IPublishMessages publisher)
        {
            this.publisher = publisher;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IPublishMessages>(publisher);
        }
    }
}