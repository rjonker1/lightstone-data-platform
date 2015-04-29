using Lim.Test.Api.Infrastructure;
using Lim.Test.Api.Models;
using Nancy;

namespace Lim.Test.Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            container.Register<IRepository<SomeDealerData>, AFakeRepository>();
        }

        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
        }
    }
}