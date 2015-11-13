using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Security;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule()
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });
            Get["/dataProviders/log"] = _ => View["DataProviders"];
        }
    }
}