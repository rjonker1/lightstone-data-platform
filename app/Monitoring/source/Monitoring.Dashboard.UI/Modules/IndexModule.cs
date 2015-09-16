using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Security;

namespace Monitoring.Dashboard.UI.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/"] = _ =>
            {
                // var model = new MonitoringStorageModel(Guid.NewGuid());

                return View["Index"];
            };

            Get["/cia"] = parameters => Response.AsRedirect(System.Configuration.ConfigurationManager.AppSettings["url/cia"].ToString());

        }
    }
}