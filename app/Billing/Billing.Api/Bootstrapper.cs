using System;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using Billing.Api.Installers;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;
using Nancy.Extensions;
using Nancy.Helpers;
using Nancy.Hosting.Aspnet;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Consumer.Installers;

namespace Billing.Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {

        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {

            this.Info(() => "Application startup initiated");
            base.ApplicationStartup(container, pipelines);

        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registations that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            container.Install(
                new NHibernateInstaller(),
                new CacheProviderInstaller(),
                new RepositoryInstaller(),
                new BusInstaller(),
                new AutoMapperInstaller(),
                new UpdateBillingTransactionInstaller(),
                new AuthenticationInstaller(),
                new ApiClientInstaller());

            //Drop create
            //new SchemaExport(container.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                this.Info(() => "Api invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
                var token = "";
                var cookie = nancyContext.Request.Headers.Cookie.FirstOrDefault(x => (x.Name + "").ToLower() == "token");
                if (cookie != null)
                    token = HttpUtility.UrlDecode(cookie.Value);

                nancyContext.Request.Headers.Authorization = "Token {0}".FormatWith(token);

                var user = container.Resolve<ITokenizer>().Detokenize(token, nancyContext, new DefaultUserIdentityResolver());
                if (user != null)
                {
                    nancyContext.CurrentUser = user;
                }
                return null;
            });
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext => this.Info(() => "Api invoked successfully at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url)));
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Api request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                var fromException = ErrorResponse.FromException(exception);
                fromException.Headers.Add("Access-Control-Allow-Origin", "*");
                fromException.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                fromException.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
                return fromException;
            });
            pipelines.EnableCors(); // cross origin resource sharing

            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            pipelines.AfterRequest.AddItemToEndOfPipeline(GetRedirectToLoginHook(null));

            base.RequestStartup(container, pipelines, context);
        }

        private static Action<NancyContext> GetRedirectToLoginHook(FormsAuthenticationConfiguration configuration)
        {
            return context =>
            {
                var contentTypes = context.Request.Headers.FirstOrDefault(x => x.Key == "Accept");
                var isHtml = (contentTypes.Value.FirstOrDefault(x => x.Contains("text/html")) + "").Any();
                if (context.Response.StatusCode == HttpStatusCode.Unauthorized && isHtml)
                    context.Response = context.GetRedirect(ConfigurationManager.AppSettings["cia/auth"]);
            };
        }

        protected override IRootPathProvider RootPathProvider
        {
            get
            {
                return new AspNetRootPathProvider();
            }
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

    }
}