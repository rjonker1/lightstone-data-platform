using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Entities.Repository;
using Lim.Schedule.Service.Resolvers;
using Toolbox.Bmw.Finance;

namespace Lim.Schedule.Service.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<RepositoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Repositories");
            container.Register(Component.For<IRepository>().UsingFactoryMethod(() => new LimRepository()));

            container.Register(Classes.FromAssemblyContaining<SaveFinanceData>()
               .BasedOn(typeof(IPersistObject<>))
               .WithServiceAllInterfaces()
               .LifestyleTransient());

         
            _log.InfoFormat("Repositories Installed");
        }
    }
}