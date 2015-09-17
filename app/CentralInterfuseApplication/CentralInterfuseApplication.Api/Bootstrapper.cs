using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;
using Nancy.Helpers;
using Nancy.Hosting.Aspnet;

namespace CentralInterfuseApplication.Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            container.Install(FromAssembly.InThisApplication());

            //  container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            //var formsAuthConfiguration = new FormsAuthenticationConfiguration
            //{
            //    RedirectUrl = "/login",
            //    UserMapper = container.Resolve<IUserMapper>(),
            //};
            //FormsAuthentication.Enable(pipelines, formsAuthConfiguration);

            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                if (ctx.CurrentUser != null) ctx.ViewBag.UserName = ctx.CurrentUser.UserName;
                return null;
            });

            pipelines.BeforeRequest.AddItemToStartOfPipeline(nancyContext =>
            {
                //nancyContext.Request.Headers.UserAgent = "Lightstone";
                var token = "";
                var cookie = nancyContext.Request.Headers.Cookie.FirstOrDefault(x => (x.Name + "").ToLower() == "token");
                if (cookie != null)
                    token = HttpUtility.UrlDecode(cookie.Value);
                    //nancyContext.Request.Headers.Authorization = "Token {0}".FormatWith(HttpUtility.UrlDecode(token.Value));

                var user = container.Resolve<ITokenizer>().Detokenize(token, nancyContext, new DefaultUserIdentityResolver());
                if (user != null)
                    nancyContext.CurrentUser = user;
                return null;
            });
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Template"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Content"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/font-awesome"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts"));
        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new AspNetRootPathProvider(); }
        }
    }
}