using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PackageBuilder.Web.Helpers.MetadataProviders;

namespace PackageBuilder.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelMetadataProviders.Current = new ConventionMetadataProvider();
        }
    }
}
