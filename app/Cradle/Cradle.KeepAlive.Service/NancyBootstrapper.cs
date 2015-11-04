using Castle.Windsor;
using Cradle.KeepAlive.Service.Helpers.Installers;
using Nancy.Bootstrappers.Windsor;

namespace Cradle.KeepAlive.Service
{
    public class NancyBootstrapper : WindsorNancyBootstrapper
    {
        private IWindsorContainer _container;

        public NancyBootstrapper(IWindsorContainer container)
        {
            container.Install(new ApiClientInstaller());

            _container = container;
        }

        protected override IWindsorContainer GetApplicationContainer()
        {
            return _container;
        }
    }
}