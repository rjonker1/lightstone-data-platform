using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace PackageBuilder.Api.Installers
{
    public class RavenDbInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IDocumentStore>().Instance(new DocumentStore { ConnectionStringName = "packageBuilder/database" }.Initialize()));
            //container.Register(Component.For<IDocumentSession>().Instance(container.Resolve<IDocumentStore>().OpenSession()).LifestylePerWebRequest());
        }
    }
}