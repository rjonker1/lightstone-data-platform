using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class PlatformStatusModule : NancyModule
    {
        public PlatformStatusModule(IRepository<PlatformStatus> platformStatuses)
        {

            Get["/PlatformStatuses"] = _ => Response.AsJson(platformStatuses);
        }
    }
}