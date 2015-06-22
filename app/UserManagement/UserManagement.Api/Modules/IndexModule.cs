using System;
using System.Configuration;
using System.Linq;
using Nancy;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["Index"];
            };

            Get["/Home"] = parameters =>
            {
                return View["Home"];
            };

            Get["/logout"] = parameters => null;

            Get["/cia"] = parameters => Response.AsRedirect(ConfigurationManager.AppSettings["cia/auth"]);
        }
    }
}