using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class PlatformStatusModule : NancyModule
    {
        public PlatformStatusModule(IRepository<PlatformStatus> platformStatuses)
        {

            Get["/PlatformStatuses"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = platformStatuses });
            };
        }
    }
}