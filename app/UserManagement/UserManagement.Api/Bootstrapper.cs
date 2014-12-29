
using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using NHibernate.Tool.hbm2ddl;
using UserManagement.Api.Installers;

namespace UserManagement.Api
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

            //container.Install(FromAssembly.InThisApplication());
            container.Install(
                new NHibernateInstaller()
                );

            new SchemaExport(container.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
            //container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
        }
    }
}