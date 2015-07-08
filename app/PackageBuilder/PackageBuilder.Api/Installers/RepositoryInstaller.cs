using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers.DataProviders.Responses;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Api.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(INamedEntityRepository<>)).ImplementedBy(typeof(NamedEntityRepository<>)).LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<IDataProviderRepository>().BasedOn(typeof(INamedEntityRepository<>)).WithServiceAllInterfaces().LifestyleTransient());

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<IDataProviderRepository>().BasedOn(typeof(IRepository<>)).WithServiceAllInterfaces().LifestyleTransient());

            container.Register(Component.For<IAmDataProviderResponseRepository>().ImplementedBy<DataProviderResponseRepository>());
        }
    }
}