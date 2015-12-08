using System.Linq;
using Castle.Windsor;
using DataPlatform.Shared.ExceptionHandling;
using MemBus;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Helpers;
using Nancy.Hosting.Aspnet;
using PackageBuilder.Api.Helpers;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Domain.Entities.DataImports;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.Logging;

namespace PackageBuilder.Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        public Bootstrapper()
        {
            Nancy.Json.JsonSettings.MaxJsonLength = int.MaxValue;
        }
        
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            container.Resolve<IBus>().Publish(new ImportStartupData());

            //var connectionMultiplexer = container.Resolve<ConnectionMultiplexer>();
            //connectionMultiplexer.RegisterProfiler(new RedisProfiler(container.Resolve<INancyContextWrapper>()));
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            //container.Install(FromAssembly.InThisApplication());
            container.Install(WindsorInstallerCollection.Installers);

            //container.Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;

          //  container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
        }

        //void Kernel_ComponentModelCreated(ComponentModel model)
        //{
        //    if (model.LifestyleType == LifestyleType.PerWebRequest)
        //        model.CustomLifestyle = new LifestyleGroup<INancyContextWrapper>(new ComponentRegistration<INancyContextWrapper>()).HybridPerWebRequestPerThread().GetType();
        //}

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
            //pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());

            var logger = container.Resolve<IDataPlatformLogger>();

            pipelines.BeforeRequest.AddItemToStartOfPipeline(nancyContext =>
            {
                logger.Info(GetType(), "Api invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
                var token = "";
                var cookie = nancyContext.Request.Headers.Cookie.FirstOrDefault(x => (x.Name + "").ToLower() == "token");
                if (cookie != null)
                    token = HttpUtility.UrlDecode(cookie.Value);

                var user = container.Resolve<ITokenizer>().Detokenize(token, nancyContext, new DefaultUserIdentityResolver());
                if (user != null)
                {
                    nancyContext.CurrentUser = user;
                    //container.Resolve<CurrentContext>().Context = nancyContext;
                }

                //var ctxObj = new RedisProfiler(container.Resolve<INancyContextWrapper>()).CreateContextForCurrentRequest();
                //if (ctxObj != null)
                //    container.Resolve<ConnectionMultiplexer>().BeginProfiling(ctxObj);

                return null;
            });
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                logger.Info(GetType(), "Api invoked successfully at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));

                //var ctxObj = new RedisProfiler(container.Resolve<INancyContextWrapper>()).GetContext();
                //if (ctxObj != null)
                //{
                //    var timings = container.Resolve<ConnectionMultiplexer>().FinishProfiling(ctxObj);
                //    timings.ForEach(x => this.Info(() => "Redis profile -> " + x));
                //}
            });
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                logger.Error(GetType(), "Error on Api request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                var errorResponse = ErrorResponse.FromException(exception);
                if (exception is LightstoneAutoException)
                    errorResponse.StatusCode = HttpStatusCode.ImATeapot;

                return errorResponse;
            });

            //pipelines.EnableCors(); // cross origin resource sharing
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                nancyContext.Response.Headers.Add("Access-Control-Allow-Origin", nancyContext.Request.Headers.Referrer.Length > 0 ? nancyContext.Request.Headers.Referrer.Substring(0, nancyContext.Request.Headers.Referrer.Length - 1) : "*");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });
            pipelines.AddTransactionScope(container);

            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));

            base.RequestStartup(container, pipelines, context);
        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new AspNetRootPathProvider(); }
        }
    }
}