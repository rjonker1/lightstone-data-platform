using System.Web.Http;
namespace Monitoring.Projection.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			GlobalConfiguration.Configure(WebApiConfig.Register);    
        }
    }
}