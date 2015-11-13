using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Recoveries.Router.Installers
{
    public static class ContainerExtentions
    {
        public static void Install<TType>(this IWindsorContainer container, IRegistration registration)
        {
            if (!container.Kernel.HasComponent(typeof(TType)))
            {
                container.Register(registration);
            }
        }
    }
}
