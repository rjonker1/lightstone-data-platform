using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Core.Repositories;

namespace PackageBuilder.Api.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
        }
    }
}