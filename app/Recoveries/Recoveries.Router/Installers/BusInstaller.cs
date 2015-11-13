using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Recoveries.Domain.Messages;
using Recoveries.Publisher;

namespace Recoveries.Router.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBus>()
                .UsingFactoryMethod(x => BusBuilder.CreateRouterBus())
                .Named("RECOVERIES_BUS"));

            container.Register(Component.For<IRecoveriesRouter>().UsingFactoryMethod(CreateWorkflowRouter));
        }

        private static IRecoveriesRouter CreateWorkflowRouter(IKernel kernel)
        {
            return new RecoveriesRouter(kernel.Resolve<IBus>("RECOVERIES_BUS"));
        }
    }
}