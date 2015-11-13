using Nancy;

namespace Workflow.Billing.Scheduler.Service.Modules
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