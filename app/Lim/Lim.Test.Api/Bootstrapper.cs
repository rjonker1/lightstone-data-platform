using System.Linq;
using Common.Logging;
using Lim.Test.Api.Core;
using Lim.Test.Api.Data;
using Lim.Test.Api.Models.Users;
using Nancy.Authentication.Basic;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Hosting.Aspnet;
using Nancy.TinyIoc;

namespace Lim.Test.Api
{
    //public class Bootstrapper : DefaultNancyBootstrapper
    //{
    //    protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
    //    {
    //        container.Register<IRepository<SomeDealerData>, AFakeRepository>();
    //    }

    //    protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
    //    {
    //        base.ConfigureConventions(nancyConventions);
    //    }
    //}

    public class BasicAuthenticationBoostrapper : DefaultNancyAspNetBootstrapper
    {
        private readonly ILog _log = LogManager.GetLogger<BasicAuthenticationBoostrapper>();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {

            base.ApplicationStartup(container, pipelines);

            var configuration = new BasicAuthenticationConfiguration(container.Resolve<IUserValidator>(), "test-realm");
            BasicAuthentication.Enable(pipelines,configuration);

            var stateless = new StatelessAuthenticationConfiguration(c =>
            {
                const string key = "X-Auth-Token";
                string token = null;

                if (c.Request.Headers.Authorization == null || !c.Request.Headers.Authorization.Any())
                {
                    _log.ErrorFormat("No request headers are present in the request {0}", c);
                    return null;
                }

                if (c.Request.Headers.FirstOrDefault(f => f.Key == key).Value == null ||
                    string.IsNullOrEmpty(c.Request.Headers.FirstOrDefault(f => f.Key == key).Value.First()))
                {
                    _log.ErrorFormat("No Key present in the request headers");
                    return null;
                }

                token = c.Request.Headers.FirstOrDefault(f => f.Key == key).Value.First();
                _log.InfoFormat("Token used {0}", token);

                var user = container.Resolve<IUserApiMapper>();
                return user.GetUserFromToken(token);

            });
            StatelessAuthentication.Enable(pipelines, stateless);
        }

        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js/pages"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/img"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css/skins"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/jquery"));
        }

      

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IRepository, Repository>();
            container.Register<IUserApiMapper, UserApiMapper>();
            container.Register<IUserValidator, FakeBasicUser>();
        }
    }
}