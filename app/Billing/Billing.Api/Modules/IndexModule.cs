using System.Configuration;
using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;

namespace Billing.Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule()
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/"] = parameters =>
            {
                //"Billing API"
                return View["Index"];
            };

            Get["/logout"] = parameters => null;

            Get["/cia"] = parameters => Response.AsRedirect(ConfigurationManager.AppSettings["cia/auth"]);
        }
    }
}