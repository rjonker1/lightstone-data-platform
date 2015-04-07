using Billing.Scheduler.Schedules;
using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Billing.Scheduler.Modules
{
    public class Index : NancyModule
    {
        public Index(IUserAuthenticationClient userAuthenticationClient)
        {
            Get["/"] = _ =>
            {
                var test = new ApiSchedule(userAuthenticationClient);
                return Response.AsRedirect("/hangfire");
            };
        }
    }
}