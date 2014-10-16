using System.Transactions;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Infrastructure.RavenDB;
using Shared.BuildingBlocks.Api.Security;

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

            IndexInstaller.Install(container);
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            container.Install(FromAssembly.InThisApplication());

            container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
            //pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());
            pipelines.EnableCors(); // cross origin resource sharing
            pipelines.AddTransactionScope(container, new TransactionScope());
        }
    }
}