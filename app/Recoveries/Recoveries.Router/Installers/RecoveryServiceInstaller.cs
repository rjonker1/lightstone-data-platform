using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Recoveries.Router.Installers
{
    public class RecoveryServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRecoveryService>().ImplementedBy<RecoveryService>());
        }
    }
}
