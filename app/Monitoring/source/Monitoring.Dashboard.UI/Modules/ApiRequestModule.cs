using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Security;

namespace Monitoring.Dashboard.UI.Modules
{
    public class ApiRequestModule : NancyModule
    {
        public ApiRequestModule()
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });
            Get["/apiRequests/metadata"] = _ => View["ApiRequests"];
        }
    }
}