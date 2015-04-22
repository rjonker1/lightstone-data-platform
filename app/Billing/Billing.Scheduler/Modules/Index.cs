using Billing.Scheduler.Schedules;
using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Billing.Scheduler.Modules
{
    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = _ =>
            {
                return Response.AsRedirect("/hangfire");
            };
        }
    }
}