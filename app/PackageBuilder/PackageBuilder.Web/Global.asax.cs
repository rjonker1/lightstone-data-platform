using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PackageBuilder.Domain.Helpers.Windsor.Installers;
using PackageBuilder.Web.Helpers.MetadataProviders;
using PackageBuilder.Web.Helpers.Windsor.Factories;

namespace PackageBuilder.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelMetadataProviders.Current = new ConventionMetadataProvider();

            BootstrapContainer();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.Containing<WindsorInstaller>());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
