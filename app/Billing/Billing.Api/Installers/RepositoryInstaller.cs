using Billing.Api.Modules;
using Billing.Domain.Core.Repositories;
using Billing.Infrastructure.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;

namespace Billing.Api.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install RepositoryInstaller");

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<IPreBillingRepository>().BasedOn(typeof(IRepository<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<IServerPageRepo>().BasedOn(typeof(IRepository<>)).WithServiceAllInterfaces().LifestyleTransient());

            this.Info(() => "Successfully installed RepositoryInstaller");
        }
    }
}