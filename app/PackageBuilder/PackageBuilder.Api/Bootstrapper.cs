using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MemBus;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataImports;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Security;
using DataPlatform.Shared.Helpers.Extensions;

namespace PackageBuilder.Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            container.Resolve<IBus>().Publish(new ImportStartupData());
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            //container.Install(FromAssembly.InThisApplication());
            container.Install(
                new NHibernateInstaller(),
                new RepositoryInstaller(),
                new CommandInstaller(),
                new BusInstaller(),
                new NEventStoreInstaller(),
                new ServiceLocatorInstaller(),
                new AutoMapperInstaller()
                );

            container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
        }

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

            pipelines.BeforeRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                this.Info(() => "Api invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
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

            pipelines.AddTransactionScope(container);

            base.RequestStartup(container, pipelines, context);
        }
    }
}